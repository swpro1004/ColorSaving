﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour {
    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forword, right;

	// Use this for initialization
	void Start () {
        forword = Camera.main.transform.forward;
        forword.y = 0f;
        forword = Vector3.Normalize(forword);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forword;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
        {
            Move();
        }
	}

    private void Move()
    {
        Vector3 rightMovement = right * moveSpeed * Time.smoothDeltaTime * Input.GetAxis("Horizontal");
        Vector3 ForwordMovement = forword * moveSpeed * Time.smoothDeltaTime * Input.GetAxis("Vertical");

        Vector3 Movement = rightMovement + ForwordMovement;

        Vector3 direction = Vector3.Normalize(Movement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += Movement;
        }
    }
}