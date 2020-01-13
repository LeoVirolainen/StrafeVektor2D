using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public float moveSpeed;

    //sound
    public AudioSource audioSource;
    public AudioClip takeHitSound;
    public AudioClip shootSound;

	void Start() {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootSound, 0.5f);
    }

	void Update() {
		transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Enemy")) {
            audioSource.PlayOneShot(takeHitSound, 0.7f);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}

}
