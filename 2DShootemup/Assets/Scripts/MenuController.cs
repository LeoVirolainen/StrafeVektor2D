using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPos;
    public GameObject gameOverMenu;

    private void Update() {
        if (player == null) {
            player = GameObject.Find("Player(Clone)");
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("LeoDevScene");
    }

    public void CloseGame() {
        Application.Quit();
    }

    public void ContinueGame() {
        GameObject plr = Instantiate(player, playerPos.transform.position, Quaternion.identity) as GameObject;        
        player.GetComponent<PlayerController>().hp = 1;
        player.GetComponent<PlayerController>().filler = GameObject.Find("HPFiller").GetComponent<Image>();
        player.GetComponent<PlayerController>().gameOverMenu = GameObject.Find("GameOverMenu");
        player.GetComponent<PlayerController>().audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        gameOverMenu.SetActive(false);
    }

    public void QuitToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
