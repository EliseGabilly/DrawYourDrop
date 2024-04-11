using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    #region Variables
    private GameObject player;
    private Camera mainCamera;

    public int RewardScore { get; set; }
    public int DistanceScore { get; set; }
    public bool UseGravity { get; private set; }
    public int PickUpCount { get; set; } = 0;
    public float StartTime { get; set; } = 0;
    private string DeathCause;

    public int Hundred = 100;

    public float WorldHeight { get; private set; }
    public float WorldWidth { get; private set; }
    public float WorldLeft { get; private set; }
    public float WorldRight { get; private set; }
    #endregion

    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;

        SetGravity(false);
    }

    public void AdjustWorldSize() {
        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -mainCamera.transform.position.z));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, -mainCamera.transform.position.z));

        WorldWidth = topRight.x - bottomLeft.x;
        WorldHeight = topRight.y - bottomLeft.y;

        WorldLeft = -WorldWidth/2;
        WorldRight = WorldWidth/2;
    }

    private void Update() {
        if (IsPlayerInFrame() && DeathCause==null) {
            DistanceScore = Mathf.Max(DistanceScore, -Mathf.FloorToInt(player.transform.position.y / 3));
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
        if (GetPlayerPosition().x > WorldRight+0.6 || GetPlayerPosition().x < WorldLeft-0.6) {
            isInFrame = false;
            Ball.Instance.WentOutOfFrame();
        } else {
            Ball.Instance.IsBouncing = false;
        }

        if (GetPlayerPosition().y > mainCamera.transform.position.y + WorldHeight/2 + 1) {
            isInFrame = false;
            if (Vector2.Equals(Vector2.zero, player.GetComponent<Rigidbody2D>().velocity)) {
                GameOver("Got stuck");
            } else {
                GameOver("Too slow");
            }
        }
        return isInFrame;
    }

    public Vector3 GetPlayerPosition() {
        return player.transform.position;
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
