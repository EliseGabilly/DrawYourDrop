using UnityEngine;

public class Bounce : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponent<Ball>().TakeBounce();
            SR.enabled = false;
            Collider.enabled = false;
            AudioSystem.Instance.PlayItem();
            GameManager.Instance.PickUpCount++;
        }
    }
}
