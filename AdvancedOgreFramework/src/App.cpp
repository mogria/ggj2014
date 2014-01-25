//|||||||||||||||||||||||||||||||||||||||||||||||

#include "App.hpp"

#include "MenuState.hpp"
#include "GameState.hpp"
#include "PauseState.hpp"

//|||||||||||||||||||||||||||||||||||||||||||||||

App::App()
{
	m_pAppStateManager = 0;
}

//|||||||||||||||||||||||||||||||||||||||||||||||

App::~App()
{
	delete m_pAppStateManager;
    delete OgreFramework::getSingletonPtr();
}

//|||||||||||||||||||||||||||||||||||||||||||||||

void App::start()
{
	new OgreFramework();
	if(!OgreFramework::getSingletonPtr()->initOgre("Runner", 0, 0))
		return;

	OgreFramework::getSingletonPtr()->m_pLog->logMessage("Runner initialized!");

	m_pAppStateManager = new AppStateManager();

	MenuState::create(m_pAppStateManager, "MenuState");
	GameState::create(m_pAppStateManager, "GameState");
    PauseState::create(m_pAppStateManager, "PauseState");

	m_pAppStateManager->start(m_pAppStateManager->findByName("GameState"));
}

//|||||||||||||||||||||||||||||||||||||||||||||||