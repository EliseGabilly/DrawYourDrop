/// <summary>
/// Serializable class savable with the save system
/// </summary>
[System.Serializable]
public class PlayerData {

    #region Variables
    public int highScore;
    public int highDistanceScore;
    public int highBonusScore;
    public int lastScore;
    public int lastDistanceScore;
    public int lastBonusScore;

    public int gamePlayed;
    public int[] scoreHistory;

    public float volumeMusic;
    public float volumeSound;

    public float[] colorBall;
    public float[] colorMagic;
    public float[] colorBackground;
    #endregion

    public PlayerData(Player player) {
        this.highScore = player.highScore;
        this.highDistanceScore = player.highDistanceScore;
        this.highBonusScore = player.highBonusScore;
        this.lastScore = player.lastScore;
        this.lastDistanceScore = player.lastDistanceScore;
        this.lastBonusScore = player.lastBonusScore;

        this.gamePlayed = player.gamePlayed;
        this.scoreHistory = player.scoreHistory.ToArray();

        this.volumeMusic = player.volumeMusic;
        this.volumeSound = player.volumeSound;

        this.colorBall = new float[] { player.colorBall.r, player.colorBall.g, player.colorBall.b };
        this.colorMagic = new float[] { player.colorMagic.r, player.colorMagic.g, player.colorMagic.b };
        this.colorBackground = new float[] { player.colorBackground.r, player.colorBackground.g, player.colorBackground.b };
    }
}
