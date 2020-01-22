using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float counter;
	public float maxCounter = 1;
	public float counter2;
	public float maxCounter2 = 1;
	public float moveSpeed;
	public bool shooting;
	public bool moving;
	public bool movingUp;
	public GameObject enemyBullet;

    public Animator enemyStayShootAnimator;

	void Start() {
        enemyStayShootAnimator = gameObject.GetComponent<Animator>();
	}

	void Update() {
		if (shooting) {
			if (counter > maxCounter) {
                enemyStayShootAnimator.Play("fire");
				GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity) as GameObject;
				bullet.transform.Rotate(new Vector3(0, 0, 90));
				Destroy(bullet, 5);

                counter = 0;
			} else {
				counter += Time.deltaTime;
			}
		}

		if (moving) {
			if (counter2 > maxCounter2) {
				if (movingUp == true) {
					movingUp = false;
				} else {
					movingUp = true;
				}
				counter2 = 0;
			} else {
				counter2 += Time.deltaTime;
			}

			if (movingUp == true) {
				transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
			} else {
				transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
			}
		}
	}
}
