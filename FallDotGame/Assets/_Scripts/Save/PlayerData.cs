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

    public string timePlayed;
    public string deathReason;
    public int pickUp;
    public int ttPickUp;
    public int linesDrawn;
    public int ttLinesDrawn;

    public int gamePlayed;
    public int[] scoreHistory;

    public int musicLevel;
    #endregion

    public PlayerData(Player player) {
        this.highScore = player.highScore;
        this.highDistanceScore = player.highDistanceScore;
        this.highBonusScore = player.highBonusScore;
        this.lastScore = player.lastScore;
        this.lastDistanceScore = player.lastDistanceScore;
        this.lastBonusScore = player.lastBonusScore;

        this.timePlayed = player.timePlayed;
        this.deathReason = player.deathReason;
        this.pickUp = player.pickUp;
        this.ttPickUp = player.ttPickUp;
        this.linesDrawn = player.linesDrawn;
        this.ttLinesDrawn = player.ttLinesDrawn;

        this.gamePlayed = player.gamePlayed;
        this.scoreHistory = player.scoreHistory.ToArray();

        this.musicLevel = player.musicLevel;
    }
}
