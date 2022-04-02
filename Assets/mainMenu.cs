using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public void Play()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Debug.Log("Jeu fermé");
        Application.Quit();
    }
}
