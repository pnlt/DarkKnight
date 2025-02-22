﻿using UnityEngine;

public class CamerController : MonoBehaviour {
    public float speed;
    public float clampLeft;
    public float clampRight;
    [SerializeField] private Transform player;

    private float cameraX;

    // Use this for initialization
    void Start () {
        cameraX = transform.position.x;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < clampRight)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > clampLeft)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(cameraX);
        }
         if (player != null)
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
