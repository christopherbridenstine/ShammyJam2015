using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {
	// The cursor object
	private GameObject cursorObject;
	// The location of the cursor in grid coordinates
	private int[] cursorGridLocation;
	// The position of the cursorGridLocation in 3d space
	private Vector3 cursorGridPosition;

	// Set the width and height of one grid square
	public int gridSquareWidth = 1;
	public int gridSquareHeight = 1;

	// Set the size of the grid in squares
	public int gridHeight = 10;
	public int gridWidth = 10;

	// Set the cursor's maximum movespeed;
	public float moveSpeed = 0.2f;

	// Use this for initialization
	void Start () {
		// Initialize an object to represent the cursor
		cursorObject = Instantiate(Resources.Load("TestCursor") as GameObject);
		// Initialize the object to start at position 0,0
		SetGridLocation (0, 0);
		// Move the cursor to a starting point location
		cursorObject.transform.position = new Vector3 (0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {
		// Check if cursor object is not currently at the correct location
		if (!IsCorrectlyLocated()) {
			MoveCursor();
		}
	}

	// Move the cursor toward or to the correct location
	void MoveCursor(){
		if (Vector3.Distance (cursorObject.transform.position, cursorGridPosition) >= moveSpeed / Time.deltaTime) {
			cursorObject.transform.position = cursorGridPosition;
		} else {
			cursorObject.transform.position += ((cursorObject.transform.position - cursorGridPosition).normalized * moveSpeed / Time.deltaTime);
		}
	}


	// This set the cursor's correct grid location to x, y
	void SetGridLocation(int x, int y){
		cursorGridLocation = new int[] {x, y};
		cursorGridPosition = new Vector3 (gridSquareWidth * (cursorGridLocation [0] + 0.5f), gridSquareHeight * (cursorGridLocation [1] + 0.5f), 0f);
	}

	// Return true if the cursorObject's in the correct position
	bool IsCorrectlyLocated(){
		return (cursorObject.transform.position == cursorGridPosition);
	}
}
