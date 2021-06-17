using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text scoreText;

    PlayerController player;
    
    private float timer = 60;
    void Start()
    {
        GameObject game = GameObject.Find("Player");
        player = game.GetComponent<PlayerController>();
        
    }

    void Update()
    {
        hpText.text = player.hp.ToString("HP: " + "00");

        timer -= Time.deltaTime;
        timeText.text = timer.ToString("Time: " + "00");

        scoreText.text = score.ToString("Score: " + "0000");
    }
    private int score = 0;
    public void ScoreCheck()
    {
        score += 100;
    }
}
