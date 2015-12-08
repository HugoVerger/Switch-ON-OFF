﻿using UnityEngine;
using System.Collections;

public class Repulsor : MonoBehaviour {

	public bool repulsor;
	public int force;
	private GameObject topCollider;
	private Vector2 angleRepulsor;
	private Vector2 angleMagnet;
	
	void Start() {
		angleRepulsor = new Vector2(Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad) * (-1),
		                            Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad)).normalized;
		angleMagnet = new Vector2(Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad),
		                          Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad) * (-1)).normalized;
		topCollider = transform.GetChild (0).gameObject;
		topCollider.SetActive (false);
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			repulsor = !repulsor;
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
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

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && repulsor)
		{
			other.GetComponent<Rigidbody2D>().AddForce(angleMagnet * force/10 * Time.deltaTime, ForceMode2D.Impulse);
			topCollider.SetActive(false);
		}
	}
}
