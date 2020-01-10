using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {
	public float moveSpeed;
	void Start() {
	}

	void Update() {
		transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
	}
}