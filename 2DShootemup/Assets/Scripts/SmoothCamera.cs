﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {
	private Transform target;
    public Transform playerPos;
	public float smoothTime = 0.3f;
	private Vector3 velocity = Vector3.zero;

	void Start() {

	}

    void Update() {
        if (playerPos.GetComponent<PlayerPos>().playerTarget != null) {
        target = playerPos.GetComponent<PlayerPos>().playerTarget.transform;
        
        transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -14));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
