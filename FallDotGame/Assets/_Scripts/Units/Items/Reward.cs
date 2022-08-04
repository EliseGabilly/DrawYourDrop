using UnityEngine;

public class Reward : Item {

    #region Variable
    public bool isMagnet = false;
    private Vector3 direction = Vector3.zero;
    private GameObject player;
    private Rigidbody2D rb;
    #endregion

    protected override void Awake() {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (isMagnet) {
            direction = (player.transform.position - this.transform.position).normalized * 10;
            rb.velocity = direction;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SR.enabled = false;
            Collider.enabled = false;
            GameManager.Instance.IncreaseScore(10);
            TweenManager.Instance.ScorePulseEffect();
            AudioSystem.Instance.PlayBonus();
            isMagnet = false;
        } else if (!isMagnet && collision.CompareTag("Magnet")) {
            isMagnet = Ball.Instance.IsMagnet;
        }
    }
}
