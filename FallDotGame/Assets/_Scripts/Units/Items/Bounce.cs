using UnityEngine;

public class Bounce : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameManager.Instance.AddToInGameBounceCount();
            collision.gameObject.GetComponent<Ball>().TakeBounce();
            SR.enabled = false;
            Collider.enabled = false;            
        }
    }
}
