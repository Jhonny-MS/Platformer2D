using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject uiEndGame;
    public GameObject hudCoins;
    public string tagToCheck = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToCheck))
        {
            CallEndGame();
        }
    }
    public void CallEndGame()
    {
        uiEndGame.SetActive(true);
        hudCoins.SetActive(false);
        Time.timeScale = 0;
    }
}
