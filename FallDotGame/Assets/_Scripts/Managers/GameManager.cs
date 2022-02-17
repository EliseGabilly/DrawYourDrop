using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    #region Variables
    private GameObject player;
    private Camera mainCamera;
    #endregion

    public int Score { get; set; }

    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
    }

    private void Update() {
        if (!IsPlayerInFrame()) {
            UiManager.Instance.FadeIn();
        }
    }

    private bool IsPlayerInFrame() {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        float xRatio = screenPos.x / mainCamera.pixelWidth; //horizontal check
        float yRatio = screenPos.y / mainCamera.pixelHeight; //vertical chack
        return !(xRatio > 1.05f || xRatio < -.05f || yRatio > 1.05f || yRatio < -.05f);
    }

    public void GameOver() {
        PlayerPrefs.SetInt("highScore", Mathf.Max(PlayerPrefs.GetInt("highScore", 0), Score));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore(int addedScore) {
        Score += addedScore;
        UiManager.Instance.UpdateScore(Score);
    }

}
