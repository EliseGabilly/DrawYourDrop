using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Player class containing the information that are "translated" in playerdata then saved
/// </summary>
public class Player : Singleton<Player> {

    #region Variables
    public int highScore = 0;
    public int highDistanceScore = 0;
    public int highBonusScore = 0;
    public int lastScore = 0;
    public int lastDistanceScore = 0;
    public int lastBonusScore = 0;

    public string timePlayed = "0:00";
    public string deathReason = "";
    public int pickUp = 0;
    public int ttPickUp = 0;
    public int linesDrawn = 0; 
    public int ttLinesDrawn = 0;

    public int gamePlayed = 0;
    public List<int> scoreHistory = new List<int>();

    public bool musicOn = true;
    #endregion

    protected override void Awake() {
        base.Awake();
        SaveSystem.LoadData();
    }

    public Player ChangeData(PlayerData data) {
        this.highScore = data.highScore;
        this.highDistanceScore = data.highDistanceScore;
        this.highBonusScore = data.highBonusScore;
        this.lastScore = data.lastScore;
        this.lastDistanceScore = data.lastDistanceScore;
        this.lastBonusScore = data.lastBonusScore;

        this.timePlayed = data.timePlayed;
        this.deathReason = data.deathReason;
        this.pickUp = data.pickUp;
        this.ttPickUp = data.ttPickUp;
        this.linesDrawn = data.linesDrawn;
        this.ttLinesDrawn = data.ttLinesDrawn;

        this.gamePlayed = data.gamePlayed;
        this.scoreHistory = new List<int>(data.scoreHistory);

        this.musicOn = data.musicOn;

        return this;
    }

    public void ChangGameStats(int score, int distanceScore, int bonusScore, float gameTime, string death, int pickUpCount, int linesDrawnCount) {

        this.lastScore = score;
        this.lastBonusScore = bonusScore;
        this.lastDistanceScore = distanceScore;
        if(this.highScore < score) {
            this.highScore = score;
            this.highDistanceScore = distanceScore;
            this.highBonusScore = bonusScore;
        }
        if (score > 5) {
            gamePlayed++;
            scoreHistory.Add(score);
            if (scoreHistory.Count > 100) {
                scoreHistory.RemoveAt(0);
            }

        }
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = (int)(gameTime % 60);
        string gameTimeTxt = String.Format("{0:00}:{1:00}", minutes, seconds);
        this.timePlayed = gameTimeTxt;
        
        this.deathReason = death;
        this.pickUp = pickUpCount;
        this.ttPickUp += pickUpCount;
        this.linesDrawn = linesDrawnCount;
        this.ttLinesDrawn += linesDrawnCount;

        SaveSystem.SavePlayer(this);
    }

    public void ChangeOptionsMusic() {
        this.musicOn = !this.musicOn;

        SaveSystem.SavePlayer(this);

        AudioSystem.Instance.SetSourcesVolume();
    }

}
