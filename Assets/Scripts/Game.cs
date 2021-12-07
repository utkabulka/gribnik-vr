using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private GameEvent onScoreChanged;
    [SerializeField]
    private GameEvent onGameOver;

    [Header("Game parameters")]
    public bool gameIsOver = false;
    [SerializeField]
    private int score = 0;
    public int Score { get => score; }
    public float Timer = 60;

    private void Start() {
        score = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            RestartGame();
        }

        if (!gameIsOver) {
            Timer -= Time.deltaTime;
            if (Timer < 0) {
                GameOver();
            }
        }
    }

    public void AddScore(int points) {
        score += points;
        onScoreChanged.Raise();
    }

    public void GameOver() {
        gameIsOver = true;
        onGameOver.Raise();
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

}
