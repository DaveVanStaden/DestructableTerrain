using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamYMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float mouseInputY = Input.GetAxis("Mouse Y");
        Vector3 lookhere = new Vector3(-mouseInputY, 0, 0);
        transform.Rotate(lookhere);
    }
}
