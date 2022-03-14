/// <summary>
/// Serializable class savable with the save system
/// </summary>
[System.Serializable]
public class PlayerData {

    #region Variables
    public int highScore;
    public int highDistanceScore;
    public int highBonusScore;

    public int gamePlayed;
    public bool haveLeapOfFaith;

    public int succesMagnetCount;
    public int succesShieldCount;
    public int succesEraseCount;
    public int succesBounceCount;

    public float volumeMusic;
    public float volumeSound;

    public int colorBall;
    public int colorMagic;
    public int colorBackground;
    #endregion

    public PlayerData(Player player) {
        this.highScore = player.highScore;
        this.highDistanceScore = player.highDistanceScore;
        this.highBonusScore = player.highBonusScore;

        this.gamePlayed = player.gamePlayed;
        this.haveLeapOfFaith = player.haveLeapOfFaith;

        this.succesMagnetCount = player.succesMagnetCount;
        this.succesShieldCount = player.succesShieldCount;
        this.succesEraseCount = player.succesEraseCount;
        this.succesBounceCount = player.succesBounceCount;

        this.volumeMusic = player.volumeMusic;
        this.volumeSound = player.volumeSound;

        this.colorBall = player.colorBall;
        this.colorMagic = player.colorMagic;
        this.colorBackground = player.colorBackground;

    }

}
