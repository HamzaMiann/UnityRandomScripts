/*
 * Author:		Hamza Mian
 * Date:		August 28, 2017
 * Version:		1.0
 * Purpose:		This script is applied to a camera and allows the user
 * 				to zoom in and out using the scrollwheel.
 * 				This is perfect for RTS games and top-down view games.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour {

	// public variables
	public float startingZoom = 30;
	public float maxZoom = 32f;
	public float minZoom = 14f;
	public float zoomSpeed = 5f;
	public float zoomInterval = 5f;

	private float currentZoom;
	private bool zoomIn = false;
	private bool zoomOut = false;
	private float targetZoom = 0f;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		currentZoom = startingZoom;
		cam.orthographicSize = currentZoom;
	}
	
	// Update is called once per frame
	void Update () {
		// get the scrollwheel direction
		float s = Input.GetAxis ("Mouse ScrollWheel");
		// if scrolling in
		if (s > 0f) {
			targetZoom = currentZoom - zoomInterval;
			if (targetZoom < minZoom)
				targetZoom = minZoom;
			zoomIn = true;
			zoomOut = false;
		}
		// if scrolling out
		else if (s < 0f) {
			targetZoom = currentZoom + zoomInterval;
			if (targetZoom > maxZoom)
				targetZoom = maxZoom;
			zoomOut = true;
			zoomIn = false;
		}
		// zoom in action
		if (zoomIn) {
			currentZoom = Mathf.Lerp (currentZoom, targetZoom, Time.fixedDeltaTime * zoomSpeed);
			cam.orthographicSize = currentZoom;
			if (currentZoom <= targetZoom + 0.05f) {
				zoomIn = false;
			}
		}
		// zoom out action
		if (zoomOut) {
			currentZoom = Mathf.Lerp (currentZoom, targetZoom, Time.fixedDeltaTime * zoomSpeed);
			cam.orthographicSize = currentZoom;
			if (currentZoom >= targetZoom - 0.05f) {
				zoomOut = false;
			}
		}
	}
}
