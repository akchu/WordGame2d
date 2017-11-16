using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryAlpha : MonoBehaviour 
{

	Rigidbody2D rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		rb.gravityScale = 0.1f;

		if (transform.position.y < -12)
			Destroy (gameObject);
	}

}
