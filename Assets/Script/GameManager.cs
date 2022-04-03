using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject body;


    public void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if ((scene.name != "GameOver") && (scene.name != "MainMenu"))
            scoreText.text = score.ToString();
        if (scene.name == "MainMenu")
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        

        if (HealthBar.health <= 0)
            Debug.Log("t'es mort");



    }
}
