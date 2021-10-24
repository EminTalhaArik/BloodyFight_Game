using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    AudioSource menuSound;

    private void Start()
    {
        menuSound = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        menuSound.Play();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        menuSound.Play();
        Application.Quit();
    }
}