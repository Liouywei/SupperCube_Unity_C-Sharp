using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PressKey : MonoBehaviour {
	public Text ptxt;
	private bool gameReady = false;

	public GameObject logopic;
	private Animator logo;

	void FixedUpdate()
	{
		if (gameReady)
		{
			if (Input.anyKeyDown)
				Application.LoadLevel (1);
		}
	}

	void ReadyStart () {
		InvokeRepeating ("TextShow", 0, 1);
		gameReady = true;
	}

	void TextShow()
	{
		ptxt.text = (ptxt.text == "") ? "Press Any Key" : "";
	}
	
	void SeeLogo()
	{
		logo = logopic.GetComponent<Animator> ();
		logo.Play ("logo");
	}
}
