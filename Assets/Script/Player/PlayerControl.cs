using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private Rigidbody2D body;
	private Animator animator;
	public GameObject scoreTxt;
	
	public float speed = 10f;
	public float jumpHeight = 10f;
	
	private bool isGround = false;
	private int jumpCount = 3;
	private bool ondamage = false;
	private bool isDead = false;
	private int health;
	private bool winLevel = false;
	private bool winFinal = false;
	
	void Start () {
		health = 3;
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	void Update () {
		if (!ondamage) {Move ();}
		AnimaState ();
	}
	
	//-------------------about Collision---------------------
	void OnCollisionEnter2D(Collision2D co)
	{
		if(co.contacts[0].normal == Vector2.up)
		{
			isGround = true;
			jumpCount =3;
		}
	}
	
	//---------------------------------------------------------
	
	void Move()
	{
		if (winFinal || isDead) {return;}
		
		Vector2 v = body.velocity;
		Vector2 temp = transform.localScale;
		
		v.x = Input.GetAxis ("Horizontal") * speed;
		//v.y = (Input.GetKeyDown(KeyCode.Space) && isGround) ? Input.GetAxis ("Jump") * jumpHeight : body.velocity.y;
		if(Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			jumpCount--;
			if(jumpCount > 0)
			{v.y = Input.GetAxis ("Jump") * jumpHeight;}
			else
			{isGround = false;}
		}
		body.velocity = v;
		
		if(v.x != 0)
		{
			temp.x = Mathf.Sign(v.x) == 1 ? 1 : -1;
		}
		transform.localScale = temp;
	}
	
	void AnimaState()
	{
		animator.SetBool ("Sleep", winFinal);
		animator.SetBool ("Dead", isDead);
		
		if (!winLevel) {animator.SetBool ("Hurt", ondamage);}
	}
	
	//-------------------about life---------------------
	void GetHurt()
	{
		if (health < 1) {return;}
		
		health --;
		ondamage = true;
		if (health < 1) {Death();}
	}
	
	void Death()
	{
		isDead = true;
		ondamage = true;
	}
	
	void LostLife()
	{
		GameMemory.life --;
	}
	
	void Action()
	{
		ondamage = false;
	}
	
	void WinLevel()
	{
		winLevel = true;
		ondamage = true;
	}
	
	void FinalWin()
	{
		winFinal = true;
	}
	
	void BackLoading()
	{
		Application.LoadLevel (1);
	}
	//----------------------------------------------------
	
	//-----------------about Score---------------------
	void AddScore(int point)
	{
		scoreTxt.SendMessage ("UpdateScore", point);
	}
	//----------------------------------------------------
	
	//-------------------Win The Final--------------------
	void TriggerEndGame()
	{
		GameObject.Find("BlackBoard").GetComponent<Animator>().Play ("BlackBoard");
		Invoke ("FinalLvel", 3);
	}
	
	void FinalLvel()
	{
		Application.LoadLevel (5);
	}
}
