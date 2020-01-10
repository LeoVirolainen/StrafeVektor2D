using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public float moveSpeed;
	void Start() {
	}

	void Update() {
		transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Enemy")) {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}

}
