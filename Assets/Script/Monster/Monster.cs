using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	public float force;
	public float speed;
	private bool attack = false;
	public Transform[] wayPoint = new Transform[2];
	private int currentNum = 0;
	public int waitTime;

	void FixedUpdate()
	{	
		if (!attack)
			Move ();
	}

	void OnCollisionEnter2D(Collision2D co)
	{
		if (co.gameObject.tag != "Player"){return;}

		attack = true;
		Invoke ("KeepMove", 3);
		co.gameObject.SendMessage("GetHurt");
		co.rigidbody.AddForce(-co.contacts[0].normal  * force);
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if(co.gameObject.tag == "WayPoint")
		{
			Invoke("NextWayPoint", waitTime);
		}
	}

	void Move()
	{
		Vector2 dis = wayPoint [currentNum].position - transform.position;
		Vector2 m = transform.localScale;
		transform.Translate (dis * Time.deltaTime *speed);
		m.x = Mathf.Sign(dis.x) == 1 ? -1 : 1;
		transform.localScale = m;
	}

	void KeepMove()
	{
		attack = false;
	}

	void NextWayPoint()
	{
		currentNum = (currentNum == 0) ? 1 : 0;
	}
}
