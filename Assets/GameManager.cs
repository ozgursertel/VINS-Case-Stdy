using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager ınstance;

    public static GameManager Instance { get => ınstance; set => ınstance = value; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public bool isGameFinished;
    public int gameScore;
    private float timer = 0;
    public int textWrite;
    public TMPro.TMP_Text text;
    public Animation finish_animation;

    private void Start()
    {
        isGameFinished = false;
        gameScore = 0;
        text.text = textWrite.ToString();
    }

    public void addScore(int score)
    {
        gameScore = gameScore + score;

    }

    private void Update()
    {
        if (isGameFinished)
        {
            return;
        }
        if (gameScore >= 10)
        {
            endGame();
        }

        timer += Time.deltaTime;
        if(timer >= 1)
        {
            setTimer();
            timer = 0;
        }

    }

    private void endGame()
    {
        isGameFinished = true;
        GameObject.Find("Player").GetComponent<Animator>().SetBool("Game Over", true);
        finish_animation.Play();
    }

    private void setTimer()
    {
        textWrite = textWrite - 1;
        text.text = textWrite.ToString();
        if(textWrite == 0 || textWrite < 0)
        {
            endGame();
        }
    }
}
