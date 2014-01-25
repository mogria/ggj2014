#pragma once

#include <Rocket\Core.h>
#include <Ogre.h>

#include "RenderInterfaceOgre3D.hpp"
#include "SystemInterfaceOgre3D.hpp"

class RocketOverlaySystem : public Ogre::RenderQueueListener
{
public:
	RocketOverlaySystem(Rocket::Core::Context* context, Ogre::RenderWindow* window);
	virtual ~RocketOverlaySystem();

protected:
	//called from ogre before queue group gets rendered
	virtual void renderQueueStarted(Ogre::uint8 queueGroupId, const Ogre::String& invocation, bool& skipThisInvocation);
	//called from ogre after group is rendered
	virtual void renderQueueEnded(Ogre::uint8 queueGroupId, const Ogre::String& invocation, bool& skipThisInvocation);

private:
	// Configures Ogre's rendering system for rendering Rocket.
	void ConfigureRenderSystem();
	// Builds an OpenGL-style orthographic projection matrix.
	void BuildProjectionMatrix(Ogre::Matrix4& matrix);

	Rocket::Core::Context* mContext;
	Ogre::RenderWindow* mWindow;
};

