using UnityEngine;

public class Reward : Item {


    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SR.enabled = false;
            Collider.enabled = false;
            GameManager.Instance.IncreaseScore(10);
        }
    }

}
