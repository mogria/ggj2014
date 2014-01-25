#include "Event.hpp"


Event::Event(const Rocket::Core::String& value, Rocket::Core::Element* element)
{
	this->element = element;
	this->value = value;
}


Event::~Event(void)
{
}


void Event::ProcessEvent(Rocket::Core::Event& event)
{

}
