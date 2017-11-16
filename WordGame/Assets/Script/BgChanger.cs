using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgChanger : MonoBehaviour 
{
	public bool Greencol;
	public bool BlueCol;
	public bool RedCol;

	// Use this for initialization
	void Start () 
	{
//		cam = GameObject.FindWithTag ("MainCamera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		cam.backgroundColor = Color.blue;
	}

	public void SetGreen()
	{
		SceneManager.LoadScene ("Game Scene");
//		cam.backgroundColor = Color.green;
		Greencol = true;
		BlueCol = false;
		RedCol = false;
	}

	public void SetRed()
	{
		SceneManager.LoadScene ("Game Scene");
//		cam.backgroundColor = Color.red;
		Greencol = false;
		BlueCol = false;
		RedCol = true;
	}

	public void Setblue()
	{
		SceneManager.LoadScene ("Game Scene");
//		cam.backgroundColor = Color.blue;
		Greencol = false;
		BlueCol = true;
		RedCol = false;
	}

//	IEnumerator LoadSceneNow ()
//	{
//		SceneManager.LoadScene ("Game Scene");
//		yield return new WaitForSeconds (1);
//
//	}
}
