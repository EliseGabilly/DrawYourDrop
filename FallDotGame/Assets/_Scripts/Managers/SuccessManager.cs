using UnityEngine;
using UnityEngine.UI;

public class SuccessManager : Singleton<SuccessManager> {

    #region Variables
    [SerializeField]
    private Text scores;

    #endregion

    public void LoadSuccess() {
        scores.text = string.Format("High score : {0}\nBy distance : {1}\nFrom bonus : {2}", 
            Player.Instance.highScore, Player.Instance.highBonusScore, Player.Instance.highDistanceScore);
    }


}
