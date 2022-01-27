using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {

	void OnCollisionExit(Collision co)
	{
		if(co.contacts[0].normal == Vector3.up)
		{
			GetComponent<Animator>().Play("BlockDead");

			if(Random.value > 0.5)
				Instantiate(Resources.Load("Coin"), transform.position, transform.rotation);
		}
	}

	void Dead()
	{
		Camera.main.SendMessage ("PlaySound", 1);
		Destroy (gameObject);
	}	
}
