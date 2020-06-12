using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

    public Transform playerCam, character, centerPoint;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;

    //keep track of the movement

    private float moveFB, moveLR;
    public float moveSpeed = 2f;

    private float zoom;
    public float zoomSpeed = 2;

    public float zoomMin = -2f;
    public float zoomMax = -10f;


	// Use this for initialization
	void Start () {

        zoom = -3;

    }
	
	// Update is called once per frame
	void Update () {

        zoom += Input.GetAxis("Mouse Scrollwheel") * zoomSpeed;

        if (zoom > -zoomMin)
            zoom = zoomMin;

        if (zoom < zoomMax)
            zoom = zoomMax;

        playerCam.transform.position = new Vector3(0, 0, zoom);


	}
}
