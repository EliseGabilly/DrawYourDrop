using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager> {

    #region Variables
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text hightScoreTitle;
    [SerializeField]
    private Text hightScore;
    [SerializeField]
    private Text lastScore;

    [Header("Canvas")]
    [SerializeField]
    private Canvas gameCanvas;
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Canvas succesCanvas;
    [SerializeField]
    private Canvas creditsCanvas;

    [Header("Background")]
    [SerializeField]
    private Image succesBg;
    [SerializeField]
    private Image creditsBg;
    #endregion

    private void Start() {
        int hScore = Player.Instance.highScore;
        int lScore = Player.Instance.lastScore;
        if (hScore == 0 && lScore == 0) {
            hightScoreTitle.enabled = false;
            hightScore.text = "Welcome";
            lastScore.text = "Start drawing to play";
        } else if (hScore == lScore) {
            hightScoreTitle.enabled = true;
            hightScore.text = Player.Instance.highScore.ToString();
            lastScore.text = "New personal best !";
        } else {
            hightScoreTitle.enabled = true;
            hightScore.text = Player.Instance.highScore.ToString();
            lastScore.text = string.Format("Last game : {0}", Player.Instance.lastScore.ToString());
        }
        score.text = "0";
        succesBg.color = Const.ColorBlueBackground;
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
        if (canvas.Equals(succesCanvas)) {
            SuccessManager.Instance.LoadSuccess();
        }
        AudioSystem.Instance.PlayClic();
    }

    public void CloseCanvases() {
        menuCanvas.enabled = false;
        succesCanvas.enabled = false;
        creditsCanvas.enabled = false; 
    }

    public void StartGame() {
        menuCanvas.enabled = false;
        succesCanvas.enabled = false;
        creditsCanvas.enabled = false;
        gameCanvas.enabled = true;
        GameManager.Instance.SetGravity(true);
        GameManager.Instance.PickUpCount = 0;
        GameManager.Instance.StartTime = Time.time;
        LineManager.Instance.LineCount = 0;
    }

    public void Quit() {
        AudioSystem.Instance.PlayClic();
        Application.Quit();
    }
}
