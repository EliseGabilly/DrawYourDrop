using UnityEngine;

public class Penalty : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SR.enabled = false;
            Collider.enabled = false;
            collision.gameObject.GetComponent<Ball>().TakeDamage();
        } else if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7) {
            ReplaceOnOverlap(collision.GetComponent<Item>());
        }
    }

}
