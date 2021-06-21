using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject rezult;

    PlayerController player;
    GameManager manager;
    
    private float timer = 60;
    void Start()
    {
        GameObject game = GameObject.Find("Player");
        player = game.GetComponent<PlayerController>();
        manager = FindObjectOfType<GameManager>();

        rezult.SetActive(false);
    }

    void Update()
    {
        hpText.text = player.hp.ToString("HP: " + "00");

        timer -= Time.deltaTime;
        timeText.text = timer.ToString("Time: " + "00");

        scoreText.text = score.ToString("Score: " + "0000");

        if (!manager.isPley)
        {
            rezult.SetActive(true);
        }
    }

    private int score = 0;
    public void ScoreCheck()
    {
        score += 100;
    }
}
