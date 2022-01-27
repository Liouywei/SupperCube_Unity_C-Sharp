using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndControl : MonoBehaviour {
	private Animator m_anim;

	public Text scoreTitle;
	public Text scoreTxt;
	private int score = 0;          //目前分數
	private int addscore = 10;   //得分
	private int maxN;              //最後正確的得分

	public Text completeTxt;
	private Animator completeAnim;

	public GameObject player;
	private Animator playerAnim;

	void Start () {
		m_anim = GetComponent<Animator> ();
		playerAnim = player.GetComponent<Animator> ();

		m_anim.Play ("ScoreTitle");
	}

	//---------------------------------------------------about Score
	void LastScore()
	{
		maxN = GameMemory.score;
		InvokeRepeating ("RunAdd", 0f, 0.02f);
	}						

	void RunAdd()
	{
		if (score != maxN)
		{
			score += addscore;
			ChangeScoreTxt (score);
		}
		else
		{
			CancelInvoke("RunAdd");	
			m_anim.Play ("CompleteWord");
		}
	}
	
	void ChangeScoreTxt(int s)
	{
		string txtLength = "0000";
		string number = ""+s;
		scoreTxt.text = txtLength.Substring (0, txtLength.Length - number.Length) + number;
	}
	//---------------------------------------------------

	//---------------------------------------------------about EndWord
	void TextDispear()
	{
		InvokeRepeating("TextChange",0, 0.5f);
	}

	void TextChange()
	{
		if(completeTxt.text == "==Complete==")
		{
			completeTxt.text = ""; 
		}else
		{
			completeTxt.text = "==Complete==";
		}
	}
	//---------------------------------------------------

	//---------------------------------------------------about PlayerAnimation
	void PlayerGravity()
	{
		player.rigidbody2D.isKinematic = false;
	}

	void PlayerAnimation()
	{
		playerAnim.Play ("Player_Smile");
		Invoke ("BlackPanalAnima", 6);
	}

	void BlackPanalAnima()
	{
		m_anim.Play ("BlackPanel");
	}

	void BackStartLevel()
	{
		Application.LoadLevel (0);
	}
	//---------------------------------------------------

}
