using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {
	
	public float angle;

	public Vector3 point, axis;

	// Use this for initialization
	void Start () {
		transform.RotateAround (point, axis, angle);
	}
	
	// Update is called once per frame
	void LateUpdate () {

	}
}
