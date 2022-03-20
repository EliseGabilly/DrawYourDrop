using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    #region Variables
    private GameObject player;
    private Camera mainCamera;

    public int RewardScore { get; set; }
    public int DistanceScore { get; set; }

    private int inGameBounceCount = 0;
    private int inGameShieldCount = 0;
    private int inGameEraseCount = 0;
    private int inGameMagnetCount = 0;
    #endregion


    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
    }

    private void Update() {
        if (!IsPlayerInFrame()) {
            Ball.Instance.WentOutOfFrame();
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
        Player.Instance.ChangeHighScores(RewardScore + DistanceScore, DistanceScore, RewardScore, LineManager.Instance.IsLeapOfFaith);
        Player.Instance.ChangSuccesCount(inGameMagnetCount, inGameShieldCount, inGameEraseCount, inGameBounceCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore(int addedScore) {
        RewardScore += addedScore;
        UiManager.Instance.UpdateScore(RewardScore+ DistanceScore);
    }

    public void AddToInGameBounceCount() {
        inGameBounceCount++;
    }

    public void AddToInGameEraseCount() {
        inGameEraseCount++;
    }

    public void AddToInGameMagnetCount() {
        inGameMagnetCount++;
    }

    public void AddToInGameShieldCount() {
        inGameShieldCount++;
    }
}
