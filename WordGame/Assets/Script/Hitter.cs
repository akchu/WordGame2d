using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hitter : MonoBehaviour 
{
	public GameObject Manager;
	public Text ScreenMsg;
	public Text LifeText;
	public string[] CongoMsg;
	public string[] NegativeMsg;

	public int life = 5;
	// Use this for initialization
	void Start () 
	{
		ScreenMsg.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x <= -7.6)
			transform.position = new Vector2 (-7.6f, transform.position.y);
		else if (transform.position.x >= 7.6)
			transform.position = new Vector2 (7.6f, transform.position.y);
		
		if(Input.GetKey(KeyCode.A))
		{
			float l = transform.position.x - 1;
			transform.position = new Vector2 (l, transform.position.y);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			float l = transform.position.x + 1;
			transform.position = new Vector2 (l, transform.position.y);
		}

		//display life on top left
		LifeText.text = "Life Left: "+life;

		if (life <= 0)
		{
			StartCoroutine (TryAgainMsg ());
			Manager.GetComponent<WordsController> ().LifeGone = true;
		}
	}

	void  OnCollisionEnter2D(Collision2D hit)
	{
//		Destroy (hit.gameObject);
		int i;
		bool FoundIt = false;
		for(i = 0; i < Manager.GetComponent<WordsController>().Alpha.Length; i++)
		{
			if (hit.gameObject.name[0] == Manager.GetComponent<WordsController> ().Alpha [i]) 
			{
				Manager.GetComponent<WordsController> ().MarkUIAlpha (hit.gameObject.name[0]); //Send Character to Mark its color RED
				FoundIt = true;
				CongoMsgDisplayer ();
//				Debug.Log (Manager.GetComponent<WordsController>().Alpha[i]);
				Destroy (hit.gameObject);
				break;
			}	
		}
		if(!FoundIt)
		{
			life--;
			NegativeMsgDisplayer ();
			Destroy (hit.gameObject, 1f);
		}

	}

	//Message on Right Hit
	void CongoMsgDisplayer()
	{
		StartCoroutine (PumpUpMsg (CongoMsg[Random.Range (0, CongoMsg.Length)]));
	}

	IEnumerator PumpUpMsg(string msg)
	{
		ScreenMsg.text = msg;
		ScreenMsg.enabled = true;
		yield return new WaitForSeconds (1);
		ScreenMsg.enabled = false;
	}

	//Message on Wrong Hit
	void NegativeMsgDisplayer()
	{
		StartCoroutine (PumpDownMsg (NegativeMsg[Random.Range (0, NegativeMsg.Length)]));
	}


	IEnumerator PumpDownMsg(string msg)
	{
		ScreenMsg.text = msg;
		ScreenMsg.enabled = true;
		yield return new WaitForSeconds (1);
		ScreenMsg.enabled = false;
	}

	IEnumerator TryAgainMsg()
	{
		ScreenMsg.text = "NO WORRIES. TRY AGAIN :)";
		ScreenMsg.enabled = true;
		yield return new WaitForSeconds (3);
		ScreenMsg.enabled = false;
	}
}
