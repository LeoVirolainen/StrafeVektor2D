using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{

    public GameObject player;
    public GameObject playerTarget;

    // Update is called once per frame
    void Update()
    {        
        if (player != null) {
            transform.position = player.transform.position;
        } else {
            player = GameObject.Find("Player(Clone)");            
        }
        if (player != null)
        playerTarget = player.transform.GetChild(2).gameObject;
    }
}
