using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player1Image;
    public GameObject player2Image;

    [SerializeField]
    Text player1PointText;
    [SerializeField]
    Text player2PointText;

    public int player1Point;
    public int player2Point;

    [SerializeField]
    GameObject pauseMenuPanel;
    [SerializeField]
    GameObject finishGamePanel;

    [SerializeField]
    Text winnerPlayer;

    AudioSource menuSound;

    void Start()
    {

        menuSound = GetComponent<AudioSource>();

        pauseMenuPanel.gameObject.SetActive(false);
        finishGamePanel.gameObject.SetActive(false);

        player1Point = 0;
        player2Point = 0;

        TextRefresh();

        Time.timeScale = 1;
    }

    void Update()
    {
        
    }

    public void scoreControl()
    {
        if(player1Point >= 10)
        {
            GameFinished();
        }
        else if(player2Point >= 10)
        {
            GameFinished();
        }
    }

    public void Player1PointUpper()
    {
        player1Point++;
        TextRefresh();
        scoreControl();
    }

    public void Player2PointUpper()
    {
        player2Point++;
        TextRefresh();
        scoreControl();
    }

    public void TextRefresh()
    {
        player1PointText.text = "" + player1Point;
        player2PointText.text = "" + player2Point;
    }

    public void GameFinished()
    {
        if(player1Point > player2Point)
        {
            finishGamePanel.gameObject.SetActive(true);
            winnerPlayer.text = " Player 1 Winner ";
            Time.timeScale = 0;
            Debug.Log("Player1 Kazandı");
        }

        if(player2Point > player1Point)
        {
            finishGamePanel.gameObject.SetActive(true);
            winnerPlayer.text = " Player 2 Winner ";
            Time.timeScale = 0;
            Debug.Log("Player2 Kazandı");
        }

        if(player1Point == player2Point)
        {
            finishGamePanel.gameObject.SetActive(true);
            winnerPlayer.text = " Berabere ";
            Time.timeScale = 0;
            Debug.Log("Berabere");
        }
    }

    public void OpenPauseMenu()
    {
        menuSound.Play();
        Time.timeScale = 0;
        pauseMenuPanel.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        menuSound.Play();
        Time.timeScale = 1;
        pauseMenuPanel.gameObject.SetActive(false);
    }

    public void MainMenu() 
    {
        menuSound.Play();
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        menuSound.Play();
        SceneManager.LoadScene(1);
    }
}
