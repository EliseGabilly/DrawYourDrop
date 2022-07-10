using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    #region Variables
    private GameObject player;
    private Camera mainCamera;

    public int RewardScore { get; set; }
    public int DistanceScore { get; set; }
    public int Hundred = 100;
    public bool UseGravity { get; private set; }
    #endregion


    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
        SetGravity(false);
    }

    private void Update() {
        if (IsPlayerInFrame()) {
            DistanceScore = Mathf.Max(DistanceScore, -Mathf.FloorToInt(player.transform.position.y / 5));
            int score = RewardScore + DistanceScore;
            UiManager.Instance.UpdateScore(score);
            if (score >= Hundred) {
                Hundred += 100;
                TweenManager.Instance.ScoreRotateEffect();
            }
        }
    }

    private bool IsPlayerInFrame() {
        bool isInFrame = true;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        float xRatio = screenPos.x / mainCamera.pixelWidth; //horizontal check
        float yRatio = screenPos.y / mainCamera.pixelHeight; //vertical chack
        if (xRatio > 1.05f || xRatio < -.05f) {
            isInFrame = false;
            Ball.Instance.WentOutOfFrame();
        }
        if (yRatio > 1.05f || yRatio < -.05f) {
            isInFrame = false;
            GameManager.Instance.GameOver();
        }
        return isInFrame;
    }

    public void GameOver() {
        AudioSystem.Instance.PlayLose();
        Player.Instance.ChangeHighScores(RewardScore + DistanceScore, DistanceScore, RewardScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore(int addedScore) {
        RewardScore += addedScore;
        UiManager.Instance.UpdateScore(RewardScore + DistanceScore);
    }

    public void SetGravity(bool use) {
        UseGravity = use;
        Physics2D.gravity = use ? new Vector2(0, -9.81f) : Vector2.zero;
    }
}
