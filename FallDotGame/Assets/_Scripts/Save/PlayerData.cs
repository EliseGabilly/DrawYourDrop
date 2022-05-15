/// <summary>
/// Serializable class savable with the save system
/// </summary>
[System.Serializable]
public class PlayerData {

    #region Variables
    public int highScore;
    public int lastScore;
    public int highDistanceScore;
    public int highBonusScore;

    public int gamePlayed;
    public int leapOfFaith;

    public int succesMagnetCount;
    public int succesShieldCount;
    public int succesEraseCount;
    public int succesBounceCount;

    public float volumeMusic;
    public float volumeSound;

    public float colorBallR;
    public float colorBallG;
    public float colorBallB;
    public float colorMagicR;
    public float colorMagicG;
    public float colorMagicB;
    public float colorBackgroundR;
    public float colorBackgroundG;
    public float colorBackgroundB;
    #endregion

    public PlayerData(Player player) {
        this.highScore = player.highScore;
        this.lastScore = player.lastScore;
        this.highDistanceScore = player.highDistanceScore;
        this.highBonusScore = player.highBonusScore;

        this.gamePlayed = player.gamePlayed;
        this.leapOfFaith = player.leapOfFaith;

        this.succesMagnetCount = player.succesMagnetCount;
        this.succesShieldCount = player.succesShieldCount;
        this.succesEraseCount = player.succesEraseCount;
        this.succesBounceCount = player.succesBounceCount;

        this.volumeMusic = player.volumeMusic;
        this.volumeSound = player.volumeSound;

        this.colorBallR = player.colorBall.r;
        this.colorBallG = player.colorBall.g;
        this.colorBallB = player.colorBall.b;
        this.colorMagicR = player.colorMagic.r;
        this.colorMagicG = player.colorMagic.g;
        this.colorMagicB = player.colorMagic.b;
        this.colorBackgroundR = player.colorBackground.r;
        this.colorBackgroundG = player.colorBackground.g;
        this.colorBackgroundB = player.colorBackground.b;

    }

}
