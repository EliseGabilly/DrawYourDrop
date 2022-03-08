using UnityEngine;

public class Shield : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Shield");
        }
    }
}
