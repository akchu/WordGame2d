using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackChanger : MonoBehaviour 
{
	BgChanger bg;
	Camera cam;
	// Use this for initialization
	void Start () 
	{
		cam = GetComponent<Camera> ();
		bg = GameObject.FindWithTag ("BgColoring").GetComponent<BgChanger> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bg.BlueCol == true)
			cam.backgroundColor = new Color (0,50,100, 0);
		else if (bg.RedCol == true)
			cam.backgroundColor = new Color (130,0,0,0);
		else if (bg.Greencol == true)
			cam.backgroundColor = new Color (0,130,0,0);
	}
}
