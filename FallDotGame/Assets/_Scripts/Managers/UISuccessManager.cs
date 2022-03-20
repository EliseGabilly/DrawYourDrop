using UnityEngine;
using UnityEngine.UI;

public class UISuccessManager : Singleton<UISuccessManager> {

    #region Variables
    [SerializeField]
    private Text scores;


    [SerializeField]
    private Image successHightScore;
    [SerializeField]
    private Image successHightDistanceScore;
    [SerializeField]
    private Image successHightBonusScore;

    [SerializeField]
    private Image successLeepOfFaith;
    [SerializeField]
    private Image successShieldCount;
    [SerializeField]
    private Image successBounceCount;

    [SerializeField]
    private Image successEraseCount;
    [SerializeField]
    private Image successMagnetCount;
    [SerializeField]
    private Image successGamePlayed;

    private Color succesColorDone;
    private Color succesColorInProgress;
    #endregion

    protected override void Awake() {
        base.Awake();

        succesColorDone = Color.white;
        succesColorInProgress = Color.white;
        succesColorInProgress.a = 0.5f;
    }

    public void LoadSuccess() {
        scores.text = Player.Instance.highScore + "\n"+ Player.Instance.highBonusScore+"\n"+ Player.Instance.highDistanceScore;

        successHightScore.color = Player.Instance.highScore > 100 ? succesColorDone : succesColorInProgress;
        successHightBonusScore.color = Player.Instance.highBonusScore > 60 ? succesColorDone : succesColorInProgress;
        successHightDistanceScore.color = Player.Instance.highDistanceScore > 60 ? succesColorDone : succesColorInProgress;

        successLeepOfFaith.color = Player.Instance.haveLeapOfFaith ? succesColorDone : succesColorInProgress;
        successShieldCount.color = Player.Instance.succesShieldCount>10 ? succesColorDone : succesColorInProgress;
        successBounceCount.color = Player.Instance.succesBounceCount > 10 ? succesColorDone : succesColorInProgress;

        successEraseCount.color = Player.Instance.succesEraseCount > 10 ? succesColorDone : succesColorInProgress;
        successMagnetCount.color = Player.Instance.succesMagnetCount > 10 ? succesColorDone : succesColorInProgress;
        successGamePlayed.color = Player.Instance.gamePlayed > 20 ? succesColorDone : succesColorInProgress;
    }


}
