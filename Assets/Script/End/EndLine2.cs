using UnityEngine;
using System.Collections;

public class EndLine2 : MonoBehaviour {
	public GameObject player;
	public GameObject scoreTxt;
	void OnTriggerEnter2D(Collider2D co)
	{
		if(co.tag != "Player"){return;}

		scoreTxt.SendMessage ("SaveScore");
		Invoke ("FinalEnd", 3);
	}

	void FinalEnd()
	{
		player.SendMessage("FinalWin");
	}
}
