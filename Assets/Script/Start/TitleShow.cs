using UnityEngine;
using System.Collections;

public class TitleShow : MonoBehaviour {
	private Animator cameraAnim;
	
	void Start () {
		cameraAnim = Camera.main.GetComponent<Animator> ();
	}
	
	void CamAnimation()
	{
		cameraAnim.Play ("cameraBackGround");
	}
}
