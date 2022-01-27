using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ToNextLevel : MonoBehaviour {
	public Text levelTxt;
	public Text lifeTxt;
	public Text scoreTxt;

	// Use this for initialization
	void Start () {
		PlayerData ();
		Invoke ("Loading", 3);
	}

	void PlayerData()
	{
		string strlen = "0000";
		string scolen = "" + GameMemory.score;
		 
		levelTxt.text = ""+(GameMemory.level - 1);
		lifeTxt.text = "" + GameMemory.life;
		scoreTxt.text = strlen.Substring(0, strlen.Length - scolen.Length) + scolen;
		//print ("score :" + GameMemory.score + " life:" + GameMemory.life + " level:" + (GameMemory.level-1));
	}

	void Loading()
	{
		int x = (GameMemory.life > 0) ? GameMemory.level : 0;
		Application.LoadLevel (x);
	}
}
