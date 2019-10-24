///Imports and namespace
#include <iostream>
#include "robot.h"
using namespace std;

///Global variables used in the program (to hide)
enum direction{	FORWARD = 0, BACKWARD = 180, LEFT = -90, RIGHT = 90};
Robot r;

///Main function that executes code
int main()
{
	//Format to output something in the console, add << between different types of variables (eg. string << int << string) and finish the line with "<< endl;"
    cout << "Hello World!" << endl << endl;

	//Call of the object Robot to use it's functions
	r.move(RIGHT,3);
	r.say("Fuck you !");

	r.move(180,5);
	r.say(10);

	r.forward();

	//Returns no errors.
	return 0;
}


///Step 1 Hello world
/*
Pitch: Player is asked to react and say something.

Objective: Introduction to console logging, represented in the game by the robot speaking.

Result: Player learns console logging.
*/

///Step 2 Move around
/*
Pitch: Player is asked to reach a target location.

Objective: Practice console logging and introduction to function calling.

Result: Player learns function calling.
*/

///Step 3 Loops
/*
Pitch: Player is asked to reach a target location with limited usage of functions.

Objective: Use loops to avoid duplicate lines of code.

Result: Player learns for and while loops.
*/

///Steps 3 Function arguments
/*
Pitch: Player is asked to optimise code by creating a movement function that requires arguments.

Objective: Create a function to move in a direction for x tiles using loops and function calling

Result: Player learns arguments in functions and code readability
*/

///Step 4 "Final test"
/*
Pitch: Player is asked to complete multiple tasks to reinvest all the learnt content. (possibly with a blank robot)

Objective: Complete a complex objective that requires to use all the aquired skills previously learnt. Creating a new function that picks an object or pushes it to a specific location.

Result: Player completes the game.
*/