using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager> {

    #region Variables
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text highScoreTitle;
    [SerializeField]
    private Text highScore;
    [SerializeField]
    private Text lastScore;

    [Header("Canvas")]
    [SerializeField]
    private Canvas gameCanvas;
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]

    private Canvas successCanvas;
    [SerializeField]
    private Canvas creditsCanvas;

    [Header("Background")]
    [SerializeField]
    private Image successBg;
    [SerializeField]
    private Image creditsBg;
    #endregion

    private void Start() {
        int hScore = Player.Instance.highScore;
        int lScore = Player.Instance.lastScore;
        if (hScore == 0 && lScore == 0) {
            highScoreTitle.enabled = false;
            highScore.text = "Welcome";
            lastScore.text = "Start drawing to play\nAnd try to keep in frame";
        } else if (hScore == lScore) {
            highScoreTitle.enabled = true;
            highScore.text = Player.Instance.highScore.ToString();
            lastScore.text = "New personal best !";
        } else {
            highScoreTitle.enabled = true;
            highScore.text = Player.Instance.highScore.ToString();
            lastScore.text = string.Format("Last game : {0}", Player.Instance.lastScore.ToString());
        }
        score.text = "0";
        successBg.color = Const.ColorBlueBackground;
        creditsBg.color = Const.ColorBlueBackground;
    }

    private void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    public void UpdateScore(int scoreVal) {
        score.text = scoreVal.ToString();
    }

    public void OpenMenu() {
        OpenCanvas(menuCanvas);
        GameManager.Instance.SetGravity(false);
    }

    public void OpenCanvas(Canvas canvas) {
        CloseCanvases();
        canvas.enabled = true;
        if (canvas.Equals(successCanvas)) {
            SuccessManager.Instance.LoadSuccess();
        } else if (canvas.Equals(creditsCanvas)) {
            InfosManager.Instance.LoadInfos();
        }
        AudioSystem.Instance.PlayClick();
    }

    public void CloseCanvases() {
        menuCanvas.enabled = false;
        successCanvas.enabled = false;
        creditsCanvas.enabled = false; 
    }

    public void StartGame() {
        menuCanvas.enabled = false;
        successCanvas.enabled = false;
        creditsCanvas.enabled = false;
        gameCanvas.enabled = true;
        GameManager.Instance.SetGravity(true);
        GameManager.Instance.PickUpCount = 0;
        GameManager.Instance.StartTime = Time.time;
        LineManager.Instance.LineCount = 0;
    }

    public void Quit() {
        AudioSystem.Instance.PlayClick();
        Application.Quit();
    }
}
