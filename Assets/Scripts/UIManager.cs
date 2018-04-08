using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreTextDisplay;

    [SerializeField]
    private int _score = 0;

   

    // Use this for initialization
    void Start () {
        //set the score to initial value
        scoreTextDisplay.text = "Score: " + _score;

       
    }
	

    public void UpdateScore()
    {
        _score += 10;
        scoreTextDisplay.text = "Score: " + _score;
        PlayerPrefs.SetInt("PlayerScore", _score);
    }

}
