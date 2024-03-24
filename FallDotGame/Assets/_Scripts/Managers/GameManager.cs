using System.Collections;
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
    public int PickUpCount { get; set; } = 0;
    public float StartTime { get; set; } = 0;
    private string DeathCause;

    public float WorldHeight { get; private set; }
    public float WorldWidth { get; private set; }
    #endregion

    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;

        Vector3 positionTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        Vector3 positionBottomRight = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0, -mainCamera.transform.position.z));
        WorldWidth = positionBottomRight.x - positionTopLeft.x;
        WorldHeight = positionTopLeft.y - positionBottomRight.y;

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
        } else {
            Ball.Instance.IsBouncing = false;
        }
        if (yRatio > 1.2f || yRatio < -.1f) {
            isInFrame = false;
            if (Vector2.Equals(Vector2.zero, player.GetComponent<Rigidbody2D>().velocity)) {
                GameOver("Got stuck");
            } else {
                GameOver("Too slow");
            }
        }
        return isInFrame;
    }

    public void GameOver(string death) {
        if(DeathCause!=null) {
            return;
        }
        DeathCause = death;

        AudioSystem.Instance.PlayLose();
        AnimManager.Instance.FadeIn();

        Player.Instance.ChangGameStats(
            RewardScore + DistanceScore,
            DistanceScore,
            RewardScore,
            Time.time - StartTime,
            death,
            PickUpCount,
            LineManager.Instance.LineCount
        );

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
