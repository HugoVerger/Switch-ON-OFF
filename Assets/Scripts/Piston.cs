using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour {

	public bool extend;
	public int force;
	private bool previousState;
	private Animator anim;
	
	void Start() {
		previousState = extend;
		anim = GetComponent<Animator> ();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && extend)
		{
			other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force * Time.deltaTime);
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			extend = !extend;
		}
	}

	void Update () {
		if (extend != previousState)
		{
			if(extend) {
				anim.SetTrigger("pistonExtend");
			}
			else {
				anim.SetTrigger("pistonRetract");
			}
		}		
		previousState = extend;
	}
}
