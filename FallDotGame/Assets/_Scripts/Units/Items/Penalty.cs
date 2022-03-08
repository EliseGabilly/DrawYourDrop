using UnityEngine;

public class Penalty : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            UiManager.Instance.FadeIn();
        }
    }

}
