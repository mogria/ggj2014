//|||||||||||||||||||||||||||||||||||||||||||||||

#include "MenuState.hpp"

//|||||||||||||||||||||||||||||||||||||||||||||||

using namespace Ogre;

//|||||||||||||||||||||||||||||||||||||||||||||||

MenuState::MenuState()
{
    m_bQuit         = false;
    m_FrameEvent    = Ogre::FrameEvent();
}

//|||||||||||||||||||||||||||||||||||||||||||||||

void MenuState::enter()
{
	
    OgreFramework::getSingletonPtr()->m_pLog->logMessage("Entering MenuState...");

    m_pSceneMgr = OgreFramework::getSingletonPtr()->m_pRoot->createSceneManager(ST_GENERIC, "MenuSceneMgr");
    m_pSceneMgr->setAmbientLight(Ogre::ColourValue(0.0f, 0.0f, 0.0f));

    m_pSceneMgr->addRenderQueueListener(OgreFramework::getSingletonPtr()->m_pOverlaySystem);

    m_pCamera = m_pSceneMgr->createCamera("MenuCam");
    m_pCamera->setPosition(Vector3(0, 10, -50));
    m_pCamera->lookAt(Vector3(0, 0, 0));
    m_pCamera->setNearClipDistance(1);

    m_pCamera->setAspectRatio(Real(OgreFramework::getSingletonPtr()->m_pViewport->getActualWidth()) /
        Real(OgreFramework::getSingletonPtr()->m_pViewport->getActualHeight()));

    OgreFramework::getSingletonPtr()->m_pViewport->setCamera(m_pCamera);

	Rocket::Core::Context* context = OgreFramework::getSingletonPtr()->m_pContext;

	// Load the mouse cursor and release the caller's reference.
	Rocket::Core::ElementDocument* cursor = context->LoadMouseCursor("../media/libRocketsAssets/cursor.rml");
	if (cursor)
		cursor->RemoveReference();

	mDocument = context->LoadDocument("gui/menu.rml");
	if(mDocument)
	{
		mDocument->Show();
		mDocument->RemoveReference();
	}

    createScene();
}

//|||||||||||||||||||||||||||||||||||||||||||||||

void MenuState::createScene()
{
    Plane p;
    p.normal = Vector3(0,0,-1); p.d = 0;
    MeshManager::getSingleton().createPlane(
        "MenuBackground", ResourceGroupManager::DEFAULT_RESOURCE_GROUP_NAME,
		p, 49, 49, 2, 2, true, 1, 3, 3, Vector3::UNIT_Y);
    // Create an entity (the floor)
	Ogre::Entity* ent = m_pSceneMgr->createEntity("floor", "MenuBackground");
    ent->setMaterialName("Examples/BumpyMetals");
    //m_pSceneMgr->getRootSceneNode()->createChildSceneNode()->attachObject(ent);
	
	//ent = m_pSceneMgr->createEntity(Ogre::SceneManager::PrefabType::PT_CUBE);
	ent = m_pSceneMgr->createEntity("Cube.3578.mesh"); 
    ent->setMaterialName("Runner/Cubes");

	Ogre::SceneNode* sceneNode = m_pSceneMgr->getRootSceneNode()->createChildSceneNode();
	sceneNode->setScale(0.5, 3.0, 0.5);
	sceneNode->setOrientation(Ogre::Real(-0.35), Ogre::Real(0), Ogre::Real(1), Ogre::Real(0));
	sceneNode->attachObject(ent);
	sceneNode->setPosition(-15,5,0);
	
	Ogre::Light* pointLight = m_pSceneMgr->createLight("sunLight");
	pointLight->setType(Ogre::Light::LT_DIRECTIONAL);
	pointLight->setPosition(m_pCamera->getPosition());
	pointLight->setDirection(Ogre::Vector3(0,-1,1));

	 pointLight = m_pSceneMgr->createLight("pointLight");
    pointLight->setType(Ogre::Light::LT_POINT);
	pointLight->setPosition(m_pCamera->getPosition());
}

//|||||||||||||||||||||||||||||||||||||||||||||||

void MenuState::exit()
{
    OgreFramework::getSingletonPtr()->m_pLog->logMessage("Leaving MenuState...");

    m_pSceneMgr->destroyCamera(m_pCamera);
    if(m_pSceneMgr)
        OgreFramework::getSingletonPtr()->m_pRoot->destroySceneManager(m_pSceneMgr);
}

//|||||||||||||||||||||||||||||||||||||||||||||||

bool MenuState::keyPressed(const OIS::KeyEvent &keyEventRef)
{
    if(OgreFramework::getSingletonPtr()->m_pKeyboard->isKeyDown(OIS::KC_ESCAPE))
    {
        m_bQuit = true;
        return true;
    }

    OgreFramework::getSingletonPtr()->keyPressed(keyEventRef);
    return true;
}

//|||||||||||||||||||||||||||||||||||||||||||||||

bool MenuState::keyReleased(const OIS::KeyEvent &keyEventRef)
{
    OgreFramework::getSingletonPtr()->keyReleased(keyEventRef);
    return true;
}

//|||||||||||||||||||||||||||||||||||||||||||||||

bool MenuState::mouseMoved(const OIS::MouseEvent &evt)
{
	OgreFramework::getSingletonPtr()->mouseMoved(evt);
    return true;
}

//|||||||||||||||||||||||||||||||||||||||||||||||

bool MenuState::mousePressed(const OIS::MouseEvent &evt, OIS::MouseButtonID id)
{
	OgreFramework::getSingletonPtr()->mousePressed(evt, id);
    return true;
}

//|||||||||||||||||||||||||||||||||||||||||||||||

bool MenuState::mouseReleased(const OIS::MouseEvent &evt, OIS::MouseButtonID id)
{
	OgreFramework::getSingletonPtr()->mouseReleased(evt, id);
    return true;
}

//|||||||||||||||||||||||||||||||||||||||||||||||

void MenuState::update(double timeSinceLastFrame)
{
    m_FrameEvent.timeSinceLastFrame = timeSinceLastFrame;
    
	Rocket::Core::Element* info = mDocument->GetElementById("info");
	if(info)
	{
		Ogre::String fps = Ogre::StringConverter::toString(OgreFramework::getSingletonPtr()->m_pRenderWnd->getAverageFPS());

		info->SetInnerRML("Fps: " + Rocket::Core::String(fps.c_str()));
	}

	if(OgreFramework::getSingletonPtr()->m_pKeyboard->isKeyDown(OIS::KC_S))
	{
		m_pCamera->move(Ogre::Vector3::UNIT_Z * 0.2 * timeSinceLastFrame);
	}
	if(OgreFramework::getSingletonPtr()->m_pKeyboard->isKeyDown(OIS::KC_W))
	{
		m_pCamera->move(Ogre::Vector3::UNIT_Z * -0.2 * timeSinceLastFrame);
	}
	if(OgreFramework::getSingletonPtr()->m_pKeyboard->isKeyDown(OIS::KC_D))
	{
		m_pCamera->move(Ogre::Vector3::UNIT_X * -0.2 * timeSinceLastFrame);
	}
	if(OgreFramework::getSingletonPtr()->m_pKeyboard->isKeyDown(OIS::KC_A))
	{
		m_pCamera->move(Ogre::Vector3::UNIT_X * 0.2 * timeSinceLastFrame);
	}

    if(m_bQuit == true)
    {
        shutdown();
        return;
    }
}

//|||||||||||||||||||||||||||||||||||||||||||||||

void MenuState::buttonHit(OgreBites::Button *button)
{
    if(button->getName() == "ExitBtn")
        m_bQuit = true;
    else if(button->getName() == "EnterBtn")
        changeAppState(findByName("GameState"));
}

//|||||||||||||||||||||||||||||||||||||||||||||||