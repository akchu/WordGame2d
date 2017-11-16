using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordsController : MonoBehaviour 
{
	//to get array of gameobjects from inspector
	public GameObject[] Alphabets;
	public GameObject[] UIAlpha;
	public GameObject[] SpawnPos;
	public GameObject[] UISpawnPos;

	public TextAsset txtFile;

	public string[] Words;
	public char[] Alpha;

	public bool LifeGone = false; //to check if life exhausted
	float timer;
	int len;
	int WordLen;
	bool cond;


	// Use this for initialization
	void Start () 
	{
		//Get words from file

		if(txtFile != null)
		{
			Words = (txtFile.text.Split('\n'));
		}
		int num = Random.Range (0, Words.Length); //select a random word

		Alpha = Words [num].ToCharArray (); //words broken into alphabets

		for (int i=0; i < Alpha.Length; i++)
			Debug.Log(Alpha[i]);
		
		len = Alphabets.Length;
		WordLen = Alpha.Length -1;
		Debug.Log ("Word length=" + WordLen);

		SpwanUIAlphabets (); //show the word alphabets  on top right
	}


	// Update is called once per frame
	void Update () 
	{
		
		//TO make random 3 alphabets fall down in specific period of time
		timer += Time.deltaTime;	
		float seconds = Mathf.RoundToInt (timer % 60);
//		Debug.Log (seconds);
		if (seconds != 0 && seconds % 5 == 0 && cond) 
		{
			Instantiate (Alphabets [Random.Range (0, len)], SpawnPos [0].transform);
			Instantiate (Alphabets [Random.Range (0, len)], SpawnPos [1].transform);
			Instantiate (Alphabets [Random.Range (0, len)], SpawnPos [2].transform);
			cond = false;
		} 
		else if(seconds % 5 != 0)
			cond = true;

		//reload scene and load new word if the previous word is completed
		if (ShowNewWord () || (LifeGone)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}


			

	}

	//To spwan the word Alphabets on top right of screen
	void SpwanUIAlphabets()
	{
		int i;
		for (i = 0 ; i< WordLen; i++) 
		{
			int n = Alpha [i] - 65;
			Debug.Log (n);
			Instantiate (UIAlpha [n], UISpawnPos [i].transform);
		}
	}


	//To change color of the alphabets on top right
	public void MarkUIAlpha(char alphabet)
	{
		int i;
		for(i = 0; i < UISpawnPos.Length;i++)
		{
			if(UISpawnPos [i].GetComponentInChildren<SpriteRenderer> ().name[0] == alphabet)
			{
				int j;
				Debug.Log(alphabet);
				UISpawnPos [i].GetComponentInChildren<SpriteRenderer> ().color = Color.red;
				for(j = 0; j < Alpha.Length-1; i++)
				{
					if (Alpha [i] == alphabet)
					{
						Alpha [i] = '0';
						break;
					}
				}
			}
		}
	}

	//TO show new word once player has completed the given set
	bool ShowNewWord()
	{
		for(int i=0; i < Alpha.Length-1; i++)
		{
			if (Alpha [i] > 64 && Alpha [i] < 91)
				return false;
		}
		return true;
	}
}
