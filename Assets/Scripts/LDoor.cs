using UnityEngine;
using System.Collections;

public class LDoor : MonoBehaviour {

	public bool clockwise;
	private enum DoorState{TopLeft, TopRight, BottomRight, BottomLeft};
	private DoorState doorState;
	private float rotateTimer;

	void Start() {
		float angle = transform.eulerAngles.z;
		if (angle > 89 && angle < 91)
			doorState = DoorState.BottomLeft;
		else if (angle > 179 && angle < 181)
			doorState = DoorState.BottomRight;
		else if (angle > 269 && angle < 271)
			doorState = DoorState.TopRight;
		else
			doorState = DoorState.TopLeft;
		rotateTimer = -1;
	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			rotateTimer = 0;
		}
	}

	void Update(){
		if (rotateTimer >= 0 && rotateTimer < 0.8) {
			if (clockwise) {
				transform.Rotate (Vector3.forward, -112 * Time.deltaTime);
			} else {
				transform.Rotate (Vector3.forward, 112 * Time.deltaTime);
			}
			rotateTimer += Time.deltaTime;
		} else if (rotateTimer > 0.8) {
			fixAngle();
		}
	}

	private void fixAngle()
	{
		if (clockwise) {
			switch (doorState)
			{
			case DoorState.TopLeft:
				transform.eulerAngles = new Vector3(0,0,270);
				doorState = DoorState.TopRight;
				break;
			case DoorState.TopRight:
				transform.eulerAngles = new Vector3(0,0,180);
				doorState = DoorState.BottomRight;
				break;
			case DoorState.BottomRight:
				transform.eulerAngles = new Vector3(0,0,90);
				doorState = DoorState.BottomLeft;
				break;
			case DoorState.BottomLeft:
				transform.eulerAngles = new Vector3(0,0,0);
				doorState = DoorState.TopLeft;
				break;				
			}
		} else {
			switch (doorState)
			{
			case DoorState.TopLeft:
				transform.eulerAngles = new Vector3(0,0,90);
				doorState = DoorState.BottomLeft;
				break;
			case DoorState.TopRight:
				transform.eulerAngles = new Vector3(0,0,0);
				doorState = DoorState.TopLeft;
				break;
			case DoorState.BottomRight:
				transform.eulerAngles = new Vector3(0,0,270);
				doorState = DoorState.TopRight;
				break;
			case DoorState.BottomLeft:
				transform.eulerAngles = new Vector3(0,0,180);
				doorState = DoorState.BottomRight;
				break;				
			}
		}
		rotateTimer = -1;
	}
}
