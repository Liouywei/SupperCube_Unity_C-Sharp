using UnityEngine;
using System.Collections;

public class Monster2 : MonoBehaviour {
	public float force;
	public Transform attackPoint;
	public Transform shotWay;
	public Rigidbody2D bullet;
	private Animator anima;
	private bool onFire;

	public int leftOrRight;
	public float shootforce;
	public int waitTime;

	void Start()
	{
		anima = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D co)
	{
		if (co.gameObject.tag != "Player"){return;}

		co.gameObject.SendMessage("GetHurt");
		co.rigidbody.AddForce(-co.contacts[0].normal  * force);
	}

	void AnimState(bool att)
	{
		anima.SetBool ("Attack", att);
	}

	void ShootBullet()
	{
		Vector2 v = (leftOrRight == 0) ? -Vector2.right : Vector2.right;

		Rigidbody2D bulletInstance;
		bulletInstance = Instantiate (bullet, shotWay.position, shotWay.rotation) as Rigidbody2D;
		bulletInstance.AddForce (v * shootforce);
	}

	void Attack()
	{
		onFire = true;
		AnimState (onFire);
	}

	void Idle()
	{
		onFire = false;
		AnimState (onFire);
	}

	void EndAttack()
	{
		AnimState (false);
		Invoke ("CheckAttack", waitTime);
	}

	void CheckAttack()
	{
		if (onFire) {
			Attack ();
		} else {
			Idle ();
		}
	}
}
