using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float upSpeed;
	public float hp = 3;
	public bool inGround;
	public bool inCeiling;
	public bool starPower;
	public bool rapidFire;
	public float SPCounter;
	public float SPMaxCounter = 10;
	public float RFCounter;
	public float RFMaxCounter = 10;
	public Image filler;
	public float counter;
	public float maxCounter = 2;
	public GameObject playerBullet;
	public GameObject rapidFirer;

	void Update() {
		transform.Translate(-Vector3.left * Time.deltaTime * moveSpeed);
		if (!Input.GetKey(KeyCode.Mouse0) && inGround == false) {
			transform.Translate(-Vector3.up * Time.deltaTime * upSpeed);
		}
		if (Input.GetKey(KeyCode.Mouse0) && inCeiling == false) {
			transform.Translate(Vector3.up * Time.deltaTime * upSpeed);
		}
		if (transform.position.y <= -4.0f) {
			inGround = true;
		}
		if (transform.position.y >= 9.0f) {
			inCeiling = true;
		}
		if (!rapidFire) {
			if (counter > maxCounter) {
				GameObject bullet = Instantiate(playerBullet, transform.position, Quaternion.identity) as GameObject;
				bullet.transform.Rotate(new Vector3(0, 0, 90));
				Destroy(bullet, 5);
				counter = 0;
			} else {
				counter += Time.deltaTime;
			}
		}
		if (starPower) {
			if (SPCounter > SPMaxCounter) {
				starPower = false;
				gameObject.GetComponent<Renderer>().material.color = Color.white;
				SPCounter = 0;
			} else {
				SPCounter += Time.deltaTime;
			}
		}
		if (rapidFire) {
			if (RFCounter > RFMaxCounter) {
				rapidFire = false;
				rapidFirer.SetActive(false);
				RFCounter = 0;
			} else {
				RFCounter += Time.deltaTime;
			}
		}
		if (hp <= 0.1f) {
			Destroy(gameObject);
		}
	}

	void TakeDamage() {
		hp -= 0.333f;
		filler.fillAmount = hp;
	}
	void GetPowerUp() {
		int rand = Random.Range(3, 0);
		switch (rand) {
			case 1:
				Debug.Log("HP++");
				if (hp < 1) {
					hp += 0.333f;
					filler.fillAmount = hp;
				}
				break;
			case 2:
				Debug.Log("STAR_POWER");
				starPower = true;
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				SPCounter = 0;
				break;
			case 3:
				Debug.Log("RAPID FIRE");
				rapidFire = true;
				rapidFirer.SetActive(true);
				RFCounter = 0;
				break;
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			inGround = true;
		}
		if (collision.gameObject.CompareTag("Ceiling")) {
			inCeiling = true;
		}
		if (collision.gameObject.CompareTag("Enemy")) {
			Destroy(collision.gameObject);
			if (!starPower) {
				TakeDamage();
			}
		}
		if (collision.gameObject.CompareTag("PowerUp")) {
			Destroy(collision.gameObject);
			GetPowerUp();
		}
	}
	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			inGround = false;
		}
		if (collision.gameObject.CompareTag("Ceiling")) {
			inCeiling = false;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("NextPieceTrigger")) {
			GameObject.Find("MapGenerator").GetComponent<MapGenerator>().inTrigger = true;
		}
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 30, 100, 20), "Lives: " + hp);
	}
}
