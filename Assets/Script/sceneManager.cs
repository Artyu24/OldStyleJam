using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class sceneManager : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject canvas;

    [SerializeField] private bool isGameOver;





    void Update()
    {
        if ((isPaused == true) && (canvas.activeSelf == false))
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
        if (isGameOver)
            GameOver();
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPaused = true;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        isPaused = false;
    }


    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

    }
}
