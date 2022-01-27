using UnityEngine;
using System.Collections;

public class ReSetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ReSet ();
	}

	void ReSet()
	{
		GameMemory.score = 0;
		GameMemory.life = 5;
		GameMemory.level = 2;
	}
}
