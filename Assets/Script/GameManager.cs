using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        scoreText.text = score.ToString();
    }
}
