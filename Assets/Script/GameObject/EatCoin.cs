using UnityEngine;
using System.Collections;

public class EatCoin : MonoBehaviour {
	private bool eaten = false;
	public int score;

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.tag != "Player" || eaten) {return;}

		eaten = true;
		GetComponent<Animator>().Play("Coin_Eat");
		co.SendMessage ("AddScore", score);
	}

	void Dead()
	{
		Destroy (gameObject);
	}
}
