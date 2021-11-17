using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text scoreText;
    private Game game;

    private void Start() {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        scoreText = GetComponent<TMP_Text>();
    }

    public void UpdateScoreText() {
        scoreText.text = "Score: " + game.Score;
    }
}
