using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour {

	public int force;
	private bool extended;
	private Animator anim;
	
	void Start() {
		extended = false;
		anim = GetComponent<Animator> ();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && !extended)
		{
			other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force * Time.deltaTime);
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if(!extended) {
				anim.SetTrigger("pistonExtend");
				extended = true;
			}
			else {
				anim.SetTrigger("pistonRetract");
				extended = false;
			}
		}
	}
}
