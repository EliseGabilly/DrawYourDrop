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

    protected override void Awake() {
        base.Awake();

        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
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

    public void FadeIn() {
        fadeAnim.SetTrigger("fade_in");
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
        FadeIn();
    }

    public void OpenCanvas(Canvas canvas) {
        CloseCanvases();
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

    public void SuccesToggleView(GameObject go) {
        Image img = go.GetComponent<Image>();
        img.enabled = !img.enabled;
        Text text = go.GetComponentInChildren<Text>();
        text.enabled = !text.enabled;
    }
}
