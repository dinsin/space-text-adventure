using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameWorld : MonoBehaviour {

	string currentRoom = "Start";
	bool newLanding = true;
	bool hasHelmet = false;
	bool hasSuit = false;
	bool hasFlag = false;
	bool needsRest = false;
	bool searchingCloset = false;
	bool checkingShelves = false;
	bool checkingContainer = false;
	bool exitingShip = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		string textBuffer = "";

		if(currentRoom == "Start"){

			textBuffer += "\nSpace Exploration Text Adventure";
			textBuffer += "\n\nby Dinesh";
			textBuffer += "\n\n\nPress [ENTER] to begin";
			textBuffer += "\n\nPress [ESCAPE] at any time to restart";

			if (Input.GetKeyDown (KeyCode.Return)) {
				currentRoom = "Cockpit";
			}

		}

		else if (currentRoom == "Cockpit") {		
		
			if (newLanding) {			
				textBuffer += "\nIt's been two hours since you landed...";
				textBuffer += "\nProbably about time you disembark and complete the mission.";
				textBuffer += "\nYou're going to need your SUIT, HELMET, and the FLAG before you leave.";
			}

			textBuffer += "\n\nYou're in the COCKPIT of the ship.";
			textBuffer += "\n\nPress [A] to head to the EXIT BAY";
			textBuffer += "\nPress [S] to enter your QUARTERS";
			textBuffer += "\nPress [D] to enter the STORAGE ROOM";

			if (Input.GetKeyDown (KeyCode.A)) {
				currentRoom = "Exit Bay";
				if (newLanding) {
					newLanding = false;
				}
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Quarters";
				if (newLanding) {
					newLanding = false;
				}
			} else if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "Storage";
				if (newLanding) {
					newLanding = false;
				}
			}
		} 

		else if (currentRoom == "Quarters") {	

			textBuffer += "\n\nYou're in your QUARTERS. The bed is in the corner to your left, and the closet is on the right.";

			if (needsRest) {
				textBuffer += "\n\n\nYou lie down for a bit...";
				textBuffer += "\n\nYou wake up a few hours later, feeling well rested.";
				textBuffer += "\nYou remember leaving some things in the storage room earlier...";
				textBuffer += "\n\nPress [ENTER] to get out of bed";

				if (Input.GetKeyDown (KeyCode.Return)) {
					needsRest = false;
				}
			} else if (searchingCloset && !hasSuit) {
				textBuffer += "\n\n\nYou open the closet door, and look inside...";
				textBuffer += "\n\nTumbling through your clothes, you uncover your space SUIT in the back.";
				textBuffer += "\nSlowly and piece-by-piece, you pull the SUIT on.";
				textBuffer += "\n\nPress [ENTER] to close the closet doors";

				if (Input.GetKeyDown (KeyCode.Return)) {
					hasSuit = true;
					searchingCloset = false;
				}
			} else if (searchingCloset && hasSuit) {
				textBuffer += "\n\n\nYou already searched the closet, and found your space SUIT!";
				textBuffer += "\n\nPress [ENTER] to reconsider";

				if (Input.GetKeyDown (KeyCode.Return)) {
					searchingCloset = false;
				}
			} else if (!needsRest && !searchingCloset) {
				textBuffer += "\n\n\nPress [A] to get some rest";
				textBuffer += "\nPress [S] to head back to the COCKPIT";
				textBuffer += "\nPress [D] to check the closet";

				if (Input.GetKeyDown (KeyCode.A)) {
					needsRest = true;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "Cockpit";
				} else if (Input.GetKeyDown (KeyCode.D)) {
					searchingCloset = true;
				}
			}
		} 

		else if (currentRoom == "Storage") {

			textBuffer += "\n\nYou squeeze into the ship's cramped STORAGE ROOM. There are crowded shelves on the wall, and some containers on the floor.";

			if (checkingShelves && !hasFlag) {
				textBuffer += "\n\nYou reach up to the shelves, feeling with your hands...";
				textBuffer += "\nYour fingers close on some fabric.";
				textBuffer += "\nYou pull the FLAG down from the shelf, and hold onto it.";
				textBuffer += "\n\nPress [ENTER] to stop rummaging through the shelves";

				if (Input.GetKeyDown (KeyCode.Return)) {
					hasFlag = true;
					checkingShelves = false;
				}
			} else if (checkingShelves && hasFlag) {
				textBuffer += "\n\n\nYou already checked the shelves, and found the FLAG!";
				textBuffer += "\n\nPress [ENTER] to reconsider";

				if (Input.GetKeyDown (KeyCode.Return)) {
					checkingShelves = false;
				}
			} else if (checkingContainer && !hasHelmet) {
				textBuffer += "\n\nYou grab a large container, and start to unlock it...";
				textBuffer += "\nYou notice glass inside, and you pull the object from the box.";
				textBuffer += "\nYou've found your space HELMET. You hold on to it, closing the container.";
				textBuffer += "\n\nPress [ENTER] to put the container away";

				if (Input.GetKeyDown (KeyCode.Return)) {
					hasHelmet = true;
					checkingContainer = false;
				}
			} else if (checkingContainer && hasHelmet) {
				textBuffer += "\n\n\nYou already searched the containers, and found your space HELMET!";
				textBuffer += "\n\nPress [ENTER] to reconsider";

				if (Input.GetKeyDown (KeyCode.Return)) {
					checkingContainer = false;
				}
			} else if (!checkingShelves && !checkingContainer) {
				textBuffer += "\n\n\nPress [A] to search the shelves";
				textBuffer += "\nPress [S] to head back to the COCKPIT";
				textBuffer += "\nPress [D] to open the containers on the floor";

				if (Input.GetKeyDown (KeyCode.A)) {
					checkingShelves = true;
					;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "Cockpit";
				} else if (Input.GetKeyDown (KeyCode.D)) {
					checkingContainer = true;
				}
			}
		} 

		else if (currentRoom == "Exit Bay") {

			textBuffer += "\n\nYou enter the ship's EXIT BAY. The DECOMPRESSION CHAMBER lies ahead of you.";

			if (exitingShip && hasSuit && hasHelmet && hasFlag) {
				textBuffer += "\n\n\nYou pull the HELMET down over your head, fastening it to your SUIT.";
				textBuffer += "\nSlowly shuffling to the door, you enter the DECOMPRESSION CHAMBER.";
				textBuffer += "\n\nPress [ENTER] to begin decompression";	

				if (Input.GetKeyDown (KeyCode.Return)) {
					currentRoom = "Outside Ship";
				}
			} else if (exitingShip && (!hasSuit || !hasHelmet || !hasFlag)) {
				textBuffer += "\n\nYou prepare to enter the DECOMPRESSION CHAMBER, but you realize you forgot something...\n";
				if (!hasSuit) {
					textBuffer += "\nYou're missing your space SUIT!";
				}
				if (!hasHelmet) {
					textBuffer += "\nYou're missing your HELMET!";
				}
				if (!hasFlag) {
					textBuffer += "\nYou're missing the FLAG! How are you supposed to complete the mission?";
				}
				textBuffer += "\n\nPress [ENTER] to go find what you're missing";

				if (Input.GetKeyDown (KeyCode.Return)) {
					exitingShip = false;
				}
			} else if (!exitingShip) {
				textBuffer += "\n\n\nPress [W] to enter the DECOMPRESSION CHAMBER";
				textBuffer += "\nPress [S] to head back to the COCKPIT";

				if (Input.GetKeyDown (KeyCode.W)) {
					exitingShip = true;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "Cockpit";
				}
			}

		} 

		else if (currentRoom == "Outside Ship") {
			textBuffer += "\n\nStanding in the chamber, you feel the pressure dropping";
			textBuffer += "\nEventually, the doors to the outside open up.";
			textBuffer += "\nYou lurch forward, slowed by the lower gravity.";
			textBuffer += "\nAfter hiking for a short while, you make your way to the top of small hill.";
			textBuffer += "\nPeering out on the strange planet, you decide this is a good spot.";
			textBuffer += "\n\nYou impale the flag into the top of the hill. Claiming this new planet, your mission is complete!";
			textBuffer += "\n\nPress [ENTER] to restart the mission";

			if (Input.GetKeyDown (KeyCode.Return)) {
				currentRoom = "Start";
				newLanding = true;
				hasHelmet = false;
				hasSuit = false;
				hasFlag = false;
				needsRest = false;
				searchingCloset = false;
				checkingShelves = false;
				checkingContainer = false;
				exitingShip = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)){
			currentRoom = "Start";
			newLanding = true;
			hasHelmet = false;
			hasSuit = false;
			hasFlag = false;
			needsRest = false;
			searchingCloset = false;
			checkingShelves = false;
			checkingContainer = false;
			exitingShip = false;
		}

		GetComponent<Text>().text = textBuffer;

	}
}