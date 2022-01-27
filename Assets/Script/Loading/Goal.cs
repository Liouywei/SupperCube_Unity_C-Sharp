using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public GameObject scoresave;
	public GameObject blackBoard;
	public GameObject timeTxt;
	private Animator endAnim;

	void Start()
	{
		endAnim = blackBoard.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if(co.tag == "Player")
		{
			timeTxt.SendMessage("StopTimer");
			co.SendMessage("WinLevel");
			endAnim.Play ("BlackBoard");
			Invoke("LevelUp", 3);
		}
	}

	void LevelUp()
	{
		scoresave.SendMessage ("SaveScore");
		GameMemory.level ++;
		Application.LoadLevel (1);
	}
}
