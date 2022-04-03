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


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "GameOver")
            scoreText.text = score.ToString();
        DontDestroyOnLoad(this.gameObject);
    }
}
