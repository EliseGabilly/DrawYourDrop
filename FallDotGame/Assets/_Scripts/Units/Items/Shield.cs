using UnityEngine;

public class Shield : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().TakeShield();
            SR.enabled = false;
            Collider.enabled = false;
        }
    }
}
