#pragma once
#include <string>
#include <iostream>

using namespace std;

class Robot
{
private:
	enum direction
	{
		//Directions are represented by the angle from forward direction
		FORWARD = 0,
		BACKWARD = 180,
		LEFT = -90,
		RIGHT = 90
	};

public:
	//Declaration of the functions with the type of argument they take if any
	void move(int, int);
	void forward();
	void backwards();
	void left();
	void right();

	//Two functions can have the same name and different arguments, it's then called an overloading of a function to handle multiple situations
	void say(string);
	void say(double);
};

