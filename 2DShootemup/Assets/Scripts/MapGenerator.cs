using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject mapPiece0;
	public GameObject mapPiece1;
	public GameObject mapPiece2;
	public GameObject powerUp;
	public GameObject lastPiece;
	private GameObject destroyablePiece;
	public GameObject instantiablePiece;
	public bool inTrigger;

	public GameObject[] mapPieces;

	void Start() {
		mapPieces = new GameObject[] { mapPiece0, mapPiece1, mapPiece2 };
	}

	void Update() {
		if (inTrigger == true) {
			CreateNextMapPiece();
			inTrigger = false;
		}
	}

	void CreateNextMapPiece() {
		int rand = Random.Range(3, 0);
		int randPU = Random.Range(3, 0);
		for (int i = 1; i <= rand; i++) {
			if (rand == i) {
				instantiablePiece = mapPieces[i - 1];
			}
		}
		Vector3 nextPiecePos = new Vector3(lastPiece.transform.position.x + 50, 0, 0);
		if (randPU == 1) {
			GameObject pwrUP = Instantiate(powerUp, nextPiecePos, Quaternion.identity) as GameObject;
		}
		GameObject piece = Instantiate(instantiablePiece, nextPiecePos, Quaternion.identity) as GameObject;
		destroyablePiece = lastPiece;
		lastPiece = piece;
		Destroy(destroyablePiece, 5);
	}
}
