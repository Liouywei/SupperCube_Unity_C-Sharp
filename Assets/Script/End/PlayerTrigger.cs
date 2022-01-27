using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {
	public GameObject ui_obj;

	void OnCollisionEnter2D(Collision2D co)
	{
		ui_obj.SendMessage ("PlayerAnimation");
	}
}
