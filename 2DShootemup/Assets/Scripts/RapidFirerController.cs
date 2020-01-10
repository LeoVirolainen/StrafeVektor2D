using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirerController : MonoBehaviour {

	public float counter;
	public float maxCounter = 0.5f;
	public float counter2;
	public float maxCounter2 = 0.5f;
	public float moveSpeed;
	public bool movingUp;
	public GameObject playerBullet;

	void Start() {

	}

	void Update() {

		if (counter2 > maxCounter2) {
			GameObject bullet = Instantiate(playerBullet, transform.position, Quaternion.identity) as GameObject;
			bullet.transform.Rotate(new Vector3(0, 0, 90));
			Destroy(bullet, 5);
			counter2 = 0;
		} else {
			counter2 += Time.deltaTime;
		}

		if (counter > maxCounter) {
			if (movingUp == true) {
				movingUp = false;
			} else {
				movingUp = true;
			}
			counter = 0;
		} else {
			counter += Time.deltaTime;
		}
		if (movingUp == true) {
			transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
		} else {
			transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
		}
	}
}
