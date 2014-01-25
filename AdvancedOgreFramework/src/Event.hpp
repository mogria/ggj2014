#pragma once

#include <Rocket\Core\EventListener.h>

class Event : public Rocket::Core::EventListener
{
public:
	Event(const Rocket::Core::String &value, Rocket::Core::Element* element);
	virtual ~Event(void);

	virtual void ProcessEvent(Rocket::Core::Event& event);

private:
	Rocket::Core::String value;
	Rocket::Core::Element* element;
};

