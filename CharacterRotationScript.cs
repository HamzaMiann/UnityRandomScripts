using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotationScript : MonoBehaviour {

	public GameObject MainCamera;
	public float lookSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
		Transform mainCamT = MainCamera.transform;
		Vector3 mainCamPos = mainCamT.position;
		Vector3 lookTarget = mainCamPos + (mainCamT.forward * 10f); // edit this
		Vector3 thisPos = transform.position;
		Vector3 lookDir = lookTarget - thisPos;
		Quaternion lookRot = Quaternion.LookRotation (lookDir);

		lookRot.x = 0;
		lookRot.z = 0;

		Quaternion newRotation = Quaternion.Lerp (transform.rotation, lookRot, Time.deltaTime * lookSpeed);
		transform.rotation = newRotation;
	}
}
