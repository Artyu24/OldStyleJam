using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class sceneManager : MonoBehaviour
{
    private bool isPaused;
    private string originalScene;
    private GameObject activeScene;
    [SerializeField] private GameObject sceneManagerObject;
    [SerializeField] private GameObject canvas;

    [SerializeField] private bool isGameOver;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOver;


    void Update()
    {
        if ((isPaused == true) && (canvas.activeSelf == false))
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            pauseMenu.SetActive(true);
            activeScene = pauseMenu;
        }
        /*
            if ((isPaused == true) && (activeScene != "Menu"))
            { 
                Time.timeScale = 0;
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                activeScene = "Menu";
                DontDestroyOnLoad(sceneManagerObject);
            }
            else if((isPaused== false) && (activeScene=="Menu"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(originalScene, LoadSceneMode.Single);
                activeScene = originalScene;
                Destroy(sceneManagerObject);
            }
        */
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
        canvas.SetActive(true);
        mainMenu.SetActive(true);
        activeScene = mainMenu;
    }
    public void Quit()
    {
        Debug.Log("Jeu fermé");
        Application.Quit();
    }
    public void Back()
    {
        activeScene.SetActive(true);
    }
    public void GameOver()
    {
        if (isGameOver == true)
        {
            canvas.SetActive(true);
            gameOver.SetActive(true);
        }
    }
}
