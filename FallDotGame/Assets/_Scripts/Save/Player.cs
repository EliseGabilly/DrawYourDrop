using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player class containing the information that are "translated" in playerdata then saved
/// </summary>
public class Player : Singleton<Player> {

    #region Variables
    public int highScore = 0;
    public int highDistanceScore = 0;
    public int highBonusScore = 0;

    public int gamePlayed = 0;
    public bool haveLeapOfFaith = false;

    public int succesMagnetCount = 0;
    public int succesShieldCount = 0;
    public int succesEraseCount = 0;
    public int succesBounceCount = 0;

    public float volumeMusic = 0.5f;
    public float volumeSound = 0.5f;

    public int colorBall = 0;
    public int colorMagic = 0;
    public int colorBackground = 0;
    #endregion

    protected override void Awake() {
        base.Awake();
        SaveSystem.LoadData();
    }

    public Player ChangeData(PlayerData data) {
        this.highScore = data.highScore;
        this.highDistanceScore = data.highDistanceScore;
        this.highBonusScore = data.highBonusScore;

        this.gamePlayed = data.gamePlayed;
        this.haveLeapOfFaith = data.haveLeapOfFaith;

        this.succesMagnetCount = data.succesMagnetCount;
        this.succesShieldCount = data.succesShieldCount;
        this.succesEraseCount = data.succesEraseCount;
        this.succesBounceCount = data.succesBounceCount;

        this.volumeMusic = data.volumeMusic;
        this.volumeSound = data.volumeSound;

        this.colorBall = data.colorBall;
        this.colorMagic = data.colorMagic;
        this.colorBackground = data.colorBackground;

        return this;
    }

    public void ChangeHighScores(int highScore, int highDistanceScore, int highBonusScore) {
        this.highScore = Mathf.Max(this.highScore, highScore);
        this.highDistanceScore = Mathf.Max(this.highDistanceScore, highDistanceScore);
        this.highBonusScore = Mathf.Max(this.highBonusScore, highBonusScore);

        SaveSystem.SavePlayer(this);
    }

}
