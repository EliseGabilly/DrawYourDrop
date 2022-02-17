using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager> {

    #region Variables
    [SerializeField]
    private Text highScore;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Animator fadeAnim;
    #endregion

    protected override void Awake() {
        base.Awake();

        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        score.text = "0";
    }

    public void UpdateScore(int scoreVal) {
        score.text = scoreVal.ToString();
    }

    public void FadeIn() {
        fadeAnim.SetTrigger("fade_in");
    }
}
