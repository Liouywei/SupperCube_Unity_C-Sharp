using UnityEngine;
using System.Collections;

public class DeadLine : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D co)
	{
		if(co.gameObject.tag == "Player")
		{
			co.gameObject.SendMessage("Death");
		}
	}
}
