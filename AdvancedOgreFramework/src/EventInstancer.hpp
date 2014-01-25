#pragma once

#include <Rocket\Core\EventListenerInstancer.h>
#include "Event.hpp"

class EventInstancer : public Rocket::Core::EventListenerInstancer
{
public:
	EventInstancer();
	virtual ~EventInstancer();

	virtual Rocket::Core::EventListener* InstanceEventListener(const Rocket::Core::String& value, Rocket::Core::Element* element);

	virtual void Release();
};

