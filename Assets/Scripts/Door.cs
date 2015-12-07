using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool changeState;
	private bool previousState;
	private bool openDoor;
	private Animator anim;

	void Start() {
		if (transform.rotation.eulerAngles.z == 0 || (transform.rotation.eulerAngles.z < 181 && transform.rotation.eulerAngles.z > 179))
			openDoor = true;
		else
			openDoor = false;
		previousState = changeState;
		anim = GetComponent<Animator> ();
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			changeState = !changeState;
		}
	}

	void Update () {
		if (changeState != previousState)
		{
			if(openDoor) {
				anim.SetTrigger("doorClose");
				openDoor = false;
			}
			else {
				anim.SetTrigger("doorOpen");
				openDoor = true;
			}
		}		
		previousState = changeState;
	}
}
