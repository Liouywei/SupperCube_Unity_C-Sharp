using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreCount : MonoBehaviour {
	public Text scoreTxt;
	private int tempScore;

	void Start()
	{
		tempScore = GameMemory.score;
		StartScore ();
	}

	void StartScore()
	{
		string len = "0000";
		string num = tempScore.ToString ();
		scoreTxt.text = len.Substring (0, len.Length - num.Length) + num;
	}
	
	void UpdateScore (int point)// point 得到分數
	{
		if (tempScore + point < 9999)	
			tempScore += point;		
		else					 
			tempScore = 9999;
		
		string number = "" + tempScore;
		string numLength = "0000";
		scoreTxt.text = numLength.Substring (0, numLength.Length - number.Length) + number;
	}

	void SaveScore()
	{
		GameMemory.score = tempScore;
	}
}
