using UnityEngine;
using System.Collections;

public class AttackPoint : MonoBehaviour {
	public GameObject myshooter;

	void OnTriggerEnter2D(Collider2D co)
	{
		if(co.tag == "Player")
		{
			myshooter.SendMessage("Attack");
		}
	}

	void OnTriggerExit2D(Collider2D co)
	{
		if(co.tag == "Player")
		{
			myshooter.SendMessage("Idle");
		}
	}
}
