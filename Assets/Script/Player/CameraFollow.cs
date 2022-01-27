using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	private Vector3 m_transform;

	void FixedUpdate () {
		Follow ();
	}

	void Follow()
	{
		m_transform.x = Mathf.Clamp (target.position.x, 7, 49);
		m_transform.y = transform.position.y;
		m_transform.z = transform.position.z;
		transform.position = m_transform;
	}
}
