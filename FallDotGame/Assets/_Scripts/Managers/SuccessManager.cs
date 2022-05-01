using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SuccessManager : Singleton<SuccessManager> {

    #region Variables
    [SerializeField]
    private Text scores;


    [SerializeField]
    private SingleSuccess successHightScore;
    [SerializeField]
    private SingleSuccess successHightDistanceScore;
    [SerializeField]
    private SingleSuccess successHightBonusScore;

    [SerializeField]
    private SingleSuccess successLeepOfFaith;
    [SerializeField]
    private SingleSuccess successShieldCount;
    [SerializeField]
    private SingleSuccess successBounceCount;

    [SerializeField]
    private SingleSuccess successEraseCount;
    [SerializeField]
    private SingleSuccess successMagnetCount;
    [SerializeField]
    private SingleSuccess successGamePlayed;

    #endregion

    public void LoadSuccess() {
        scores.text = Player.Instance.highScore + "\n"+ Player.Instance.highBonusScore+"\n"+ Player.Instance.highDistanceScore;

        successHightScore.SetCompletionTo(Player.Instance.highScore);
        successHightBonusScore.SetCompletionTo(Player.Instance.highBonusScore);
        successHightDistanceScore.SetCompletionTo(Player.Instance.highDistanceScore);

        successLeepOfFaith.SetCompletionTo(Player.Instance.leapOfFaith);
        successShieldCount.SetCompletionTo(Player.Instance.succesShieldCount);
        successBounceCount.SetCompletionTo(Player.Instance.succesBounceCount);

        successEraseCount.SetCompletionTo(Player.Instance.succesEraseCount);
        successMagnetCount.SetCompletionTo(Player.Instance.succesMagnetCount);
        successGamePlayed.SetCompletionTo(Player.Instance.gamePlayed);
    }


}
