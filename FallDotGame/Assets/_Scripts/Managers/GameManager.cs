using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    #region Variables
    private GameObject player;
    private Camera mainCamera;

    public int RewardScore { get; set; }
    public int DistanceScore { get; set; }
    #endregion


    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
    }

    private void Update() {
        if (!IsPlayerInFrame()) {
            UiManager.Instance.FadeIn();
        } else {
            DistanceScore = Mathf.Max(DistanceScore, -Mathf.FloorToInt(player.transform.position.y/5));
            UiManager.Instance.UpdateScore(RewardScore + DistanceScore);
        }
    }

    private bool IsPlayerInFrame() {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        float xRatio = screenPos.x / mainCamera.pixelWidth; //horizontal check
        float yRatio = screenPos.y / mainCamera.pixelHeight; //vertical chack
        return !(xRatio > 1.05f || xRatio < -.05f || yRatio > 1.05f || yRatio < -.05f);
    }

    public void GameOver() {
        PlayerPrefs.SetInt("highRewardScore", Mathf.Max(PlayerPrefs.GetInt("highRewardScore", 0), RewardScore));
        PlayerPrefs.SetInt("highDistanceScore", Mathf.Max(PlayerPrefs.GetInt("highDistanceScore", 0), DistanceScore));
        PlayerPrefs.SetInt("highScore", Mathf.Max(PlayerPrefs.GetInt("highScore", 0), RewardScore + DistanceScore));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore(int addedScore) {
        RewardScore += addedScore;
        UiManager.Instance.UpdateScore(RewardScore+ DistanceScore);
    }

}
