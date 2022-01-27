using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float force;

	void Start()
	{
		Destroy (gameObject, 1);
	}

	void OnCollisionEnter2D(Collision2D co)
	{
		if (co.gameObject.tag != "Player"){return;}

		co.gameObject.SendMessage("GetHurt");
		co.rigidbody.AddForce(-co.contacts[0].normal  * force);
		Destroy (gameObject);
	}


}
