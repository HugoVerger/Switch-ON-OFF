using UnityEngine;
using System.Collections;

public class Repulsor : MonoBehaviour {

	public bool repulsor;
	public int force;
	public GameObject topCollider;
	private Vector2 angleRepulsor;
	private Vector2 angleMagnet;
	
	void Start() {
		topCollider.SetActive (false);
		angleRepulsor = new Vector2(Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad) * (-1),
		                            Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad)).normalized;
		angleMagnet = new Vector2(Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad),
		                          Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad) * (-1)).normalized;
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (repulsor)
			{
				other.GetComponent<Rigidbody2D>().AddForce(angleRepulsor * force * Time.deltaTime);
				topCollider.SetActive(true);
			}
			else
			{
				other.GetComponent<Rigidbody2D>().AddForce(angleMagnet * force * Time.deltaTime);
				topCollider.SetActive(false);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && repulsor)
		{
			topCollider.SetActive(false);
			other.GetComponent<Rigidbody2D>().AddForce(angleMagnet * force/10 * Time.deltaTime, ForceMode2D.Impulse);
		}
	}
}
