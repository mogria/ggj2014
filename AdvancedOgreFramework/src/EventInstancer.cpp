#include "EventInstancer.hpp"


EventInstancer::EventInstancer(void)
{
}


EventInstancer::~EventInstancer(void)
{
}


Rocket::Core::EventListener* EventInstancer::InstanceEventListener(const Rocket::Core::String& value, Rocket::Core::Element* element)
{
	return new Event(value, element);
}


void EventInstancer::Release()
{
	delete this;
}
