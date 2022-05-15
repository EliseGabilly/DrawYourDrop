using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager> {

    #region Variables
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text hightScore;
    [SerializeField]
    private Text lastScore;

    [Header("Canvas")]
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Canvas succesCanvas;
    [SerializeField]
    private Canvas optionCanvas;
    [SerializeField]
    private Canvas creditsCanvas;
    #endregion

    private void Start() {
        hightScore.text = Player.Instance.highScore.ToString();
        lastScore.text = string.Format("Last game : {0}", Player.Instance.lastScore.ToString());
        score.text = "0";
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
        Time.timeScale = 0;
    }

    public void CloseMenuPlay() {
        CloseCanvases();
        Time.timeScale = 1; 
    }

    public void CloseMenuReplay() {
        CloseCanvases();
        Time.timeScale = 1;
        GameManager.Instance.GameOver();
    }

    public void OpenCanvas(Canvas canvas) {
        CloseCanvases();
        if (canvas.Equals(succesCanvas)) {
            SuccessManager.Instance.LoadSuccess();
        }
        canvas.enabled = true;
    }

    public void CloseCanvases() {
        menuCanvas.enabled = false;
        succesCanvas.enabled = false;
        optionCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }

    public void Quit() {
        Application.Quit();
    }
}
