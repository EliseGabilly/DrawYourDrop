using UnityEngine;

public class Bounce : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Bounce");
        }
    }
}
