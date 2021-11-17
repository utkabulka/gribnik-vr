using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    private TMP_Text timerText;
    private Game game;

    private void Start() {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        timerText = GetComponent<TMP_Text>();
    }
    
    private void FixedUpdate() {
        int minutes = (int)(game.Timer / 60);
        string sMinutes = "";
        if (minutes < 10)
            sMinutes = '0' + minutes.ToString();
        else
            sMinutes = minutes.ToString();

        int seconds = (int)(game.Timer % 60);
        string sSeconds = "";
        if (seconds < 10)
            sSeconds = '0' + seconds.ToString();
        else
            sSeconds = seconds.ToString();

        timerText.text = sMinutes + ':' + sSeconds;
    }
}
