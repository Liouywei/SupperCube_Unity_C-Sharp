using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimeCount : MonoBehaviour {
	public int timer;
	public GameObject player;
	public Text timeTxt;

	void Start () {
		InvokeRepeating ("Timmer", 0, 1);
	}

	void Timmer()
	{
		timer --;
		if (timer == 20) {timeTxt.color = Color.red;}
		timeTxt.text = "" + timer;
		if(timer == 0)
		{
			player.SendMessage("Death");
			CancelInvoke("Timmer");
		}
	}

	void StopTimer()
	{
		CancelInvoke("Timmer");
	}
}
