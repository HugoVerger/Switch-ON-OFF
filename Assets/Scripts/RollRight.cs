using UnityEngine;
using System.Collections;

public class RollRight : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * Time.deltaTime);
	}
}
