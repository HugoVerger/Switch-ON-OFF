using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour {

	public bool extend;
	private bool previousState;
	private Animator anim;
	
	void Start() {
		previousState = extend;
		anim = GetComponent<Animator> ();
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
