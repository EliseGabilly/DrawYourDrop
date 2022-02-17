using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager> {

    [SerializeField]
    private Text highScore;
    [SerializeField]
    private Text score;

    protected override void Awake() {
        base.Awake();

        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        score.text = "0";
    }

    public void UpdateScore(int scoreVal) {
        score.text = scoreVal.ToString();
    }
}
