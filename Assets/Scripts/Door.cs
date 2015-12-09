using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private bool openDoor;
	private Animator anim;

	void Start() {
		if (transform.rotation.eulerAngles.z == 0 || (transform.rotation.eulerAngles.z < 181 && transform.rotation.eulerAngles.z > 179))
			openDoor = false;
		else
			openDoor = true;
		anim = GetComponent<Animator> ();
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
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
	}
}
