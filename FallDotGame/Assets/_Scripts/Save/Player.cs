using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player class containing the information that are "translated" in playerdata then saved
/// </summary>
public class Player : Singleton<Player> {

    #region Variables
    public int highScore = 0;
    public int lastScore = 0;
    public int highDistanceScore = 0;
    public int highBonusScore = 0;

    public int gamePlayed = 0;
    public int leapOfFaith = 0;

    public int succesMagnetCount = 0;
    public int succesShieldCount = 0;
    public int succesEraseCount = 0;
    public int succesBounceCount = 0;

    public float volumeMusic = 0.5f;
    public float volumeSound = 0.5f;

    public Color colorBall = Const.ColorWhite;
    public Color colorMagic = Const.ColorBlue;
    public Color colorBackground = Const.ColorGreenLight;
    #endregion

    protected override void Awake() {
        base.Awake();
        SaveSystem.LoadData();
}

    public Player ChangeData(PlayerData data) {
        this.highScore = data.highScore;
        this.lastScore = data.lastScore;
        this.highDistanceScore = data.highDistanceScore;
        this.highBonusScore = data.highBonusScore;

        this.gamePlayed = data.gamePlayed;
        this.leapOfFaith = data.leapOfFaith;

        this.succesMagnetCount = data.succesMagnetCount;
        this.succesShieldCount = data.succesShieldCount;
        this.succesEraseCount = data.succesEraseCount;
        this.succesBounceCount = data.succesBounceCount;

        this.volumeMusic = data.volumeMusic;
        this.volumeSound = data.volumeSound;

        this.colorBall = new Color(data.colorBallR, data.colorBallG, data.colorBallB);
        this.colorMagic = new Color(data.colorMagicR, data.colorMagicG, data.colorMagicB);
        this.colorBackground = new Color(data.colorBackgroundR, data.colorBackgroundG, data.colorBackgroundB);

        return this;
    }

    public void ChangeHighScores(int highScore, int highDistanceScore, int highBonusScore, int leapOfFaith) {
        this.lastScore = highScore;
        this.highScore = Mathf.Max(this.highScore, highScore);
        this.highDistanceScore = Mathf.Max(this.highDistanceScore, highDistanceScore);
        this.highBonusScore = Mathf.Max(this.highBonusScore, highBonusScore);
        gamePlayed++;
        this.leapOfFaith = Mathf.Max(this.leapOfFaith, leapOfFaith);

        SaveSystem.SavePlayer(this);
    }

    public void ChangSuccesCount(int addedMagnetCount, int addedShieldCount, int addedEraseCount, int addedBounceCount) {
        succesMagnetCount += addedMagnetCount;
        succesShieldCount += addedShieldCount;
        succesEraseCount += addedEraseCount;
        succesBounceCount += addedBounceCount;
        SaveSystem.SavePlayer(this);
    }

    public void ChangeOptions(float volumeMusic, float volumeSound, Color colorBall, Color colorMagic, Color colorBackground) {
        this.volumeMusic = volumeMusic;
        this.volumeSound = volumeSound;

        this.colorBall = colorBall;
        this.colorMagic = colorMagic;
        this.colorBackground = colorBackground;
        SaveSystem.SavePlayer(this);
    }
}
