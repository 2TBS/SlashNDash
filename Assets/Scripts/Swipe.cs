using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Object that represents a single swipe action.
public class Swipe {

	public enum Type : int {
		Left,
        Right,
        Up,
        Down,
        BottomLeftDiagonal,
        TopLeftDiagonal,
        Tap,
        None
	}

	///Start position of the Swipe.
	public Vector2 startPosition;

	///End position of the Swipe.
	public Vector2 endPosition;

	///Type of swipe.
	public Type swipeType;

	private Vector2 midpoint;

	public Swipe (Vector2 startPos, Vector2 endPos, Type type) {
		startPosition = startPos;
		endPosition = endPos;
		swipeType = type;

		midpoint = new Vector2((startPos.x + endPos.x)/2, (startPos.y + endPos.y)/2);
	}

	public Swipe () {

	}

	///Returns if the Swipe has hit a Minion
	public bool Contains (Vector2 position, float radius) {
		if(swipeType != Type.None) {
			return(!IsInCircle(position, startPosition, radius) && !IsInCircle(position, endPosition, radius) && IsInCircle(position, midpoint, radius));
		}

		return false;
			
	}

	///Returns if 'point' is located within a circle with given center and radius
	private bool IsInCircle (Vector2 center, Vector2 point, float radius) {
		return Mathf.Pow((center.x-point.x),2) + Mathf.Pow((center.y-point.y),2) < Mathf.Pow(radius,2);
	}
}
