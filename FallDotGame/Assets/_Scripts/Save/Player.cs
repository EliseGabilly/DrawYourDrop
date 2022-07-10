using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

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

    public int gamePlayed = 0;
    public List<int> scoreHistory = new List<int>();

    public float volumeMusic = 0.5f;
    public float volumeSound = 0.5f;

    public Color colorBall = Const.ColorWhite;
    public Color colorMagic = Const.ColorBlue;
    public Color colorBackground = Const.ColorBlueLight;
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

        this.gamePlayed = data.gamePlayed;
        this.scoreHistory = new List<int>(data.scoreHistory);

        this.volumeMusic = data.volumeMusic;
        this.volumeSound = data.volumeSound;

        this.colorBall = new Color32((byte)(data.colorBall[0] * 255), (byte)(data.colorBall[1] * 255), (byte)(data.colorBall[2] * 255), 255);
        this.colorMagic = new Color32((byte)(data.colorMagic[0] * 255), (byte)(data.colorMagic[1] * 255), (byte)(data.colorMagic[2] * 255), 255);
        this.colorBackground = new Color32((byte)(data.colorBackground[0] * 255), (byte)(data.colorBackground[1] * 255), (byte)(data.colorBackground[2] * 255), 255);

        return this;
    }

    public void ChangeHighScores(int score, int distanceScore, int bonusScore) {
        this.lastScore = score;
        this.highScore = Mathf.Max(this.highScore, score);
        this.highDistanceScore = Mathf.Max(this.highDistanceScore, distanceScore);
        this.highBonusScore = Mathf.Max(this.highBonusScore, bonusScore);
        gamePlayed++;
        if (score > 5) {
            scoreHistory.Add(score);
            if (scoreHistory.Count > 100) {
                scoreHistory.RemoveAt(0);
            }

        }

        SaveSystem.SavePlayer(this);
    }

    public void ChangeOptionsMusic(float volumeMusic, float volumeSound) {
        this.volumeMusic = volumeMusic;
        this.volumeSound = volumeSound;

        SaveSystem.SavePlayer(this);
    }

    public void ChangeOptionsColors(Color colorBall, Color colorMagic, Color colorBackground) {
        this.colorBall = colorBall;
        this.colorMagic = colorMagic;
        this.colorBackground = colorBackground;

        SaveSystem.SavePlayer(this);
    }
}
