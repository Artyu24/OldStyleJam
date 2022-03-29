using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class sceneManager : MonoBehaviour
{
    private bool isPaused;
    void FixedUpdate()
    {
        if(isPaused == true)
        { 
            Debug.Log("Escape key was pressed");
            Time.timeScale = 0;
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        { 
            Debug.Log("Escape key was pressed");
            isPaused = true;
        }
        else if (context.canceled)
            isPaused = false;
    }
}
