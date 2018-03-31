using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScorePrint : MonoBehaviour {

    private int _score;
    public Text scoreTextDisplay;

    // Use this for initialization
    void Start () {
        _score = PlayerPrefs.GetInt("PlayerScore");
        Debug.Log(_score);

        scoreTextDisplay.text = "Score: " + _score;
    }
	

}
