using UnityEngine;
using System.Collections;

public class EndLine1 : MonoBehaviour {
	public GameObject player;
	public GameObject timeTxt;

	void OnTriggerEnter2D(Collider2D co)
	{
		Destroy (gameObject);
		timeTxt.SendMessage("StopTimer");
		player.rigidbody2D.fixedAngle = false;
		player.SendMessage ("WinLevel");
	}
}
