#include "robot.h"
using namespace std;

//Declaration of the code of each function
void Robot::move(int dir, int val) {
	for (int i = 0; i < val; i++)
	//Switch is the equivalent of several if (condition) else if(condition) else...
	//The switch is done on a value with a specific type
	switch (dir)
	{
	//Case is a condition which stands as if(value == case value)
	case FORWARD:
		cout << "Robot moves forward." << endl;
		//Break stops the switch and moves on after, if no break statement is written, the switch will go through the next cases
		break;

	case BACKWARD:
		cout << "Robot moves backwards." << endl;
		break;
	
	case LEFT:
		cout << "Robot moves left." << endl;
		break;
	
	case RIGHT:
		cout << "Robot moves right." << endl;
		break;
	
	//Default is a case that the switch will always go through if the switch hasn't met any break statement before, preferable to keep as last case
	default:
		cout << "No command recognized." << endl;
		break;
	}
}

void Robot::forward() {
	cout << "Robot moves forward." << endl;
}

void Robot::backwards() {
	cout << "Robot moves backwards." << endl;
}

void Robot::left() {
	cout << "Robot moves left." << endl;
}

void Robot::right() {
	cout << "Robot moves right." << endl;
}

void Robot::say(string val) {
	cout << "Robot: " << val << endl;
}

void Robot::say(double val) {
	cout << "Robot: " << val << endl;
}