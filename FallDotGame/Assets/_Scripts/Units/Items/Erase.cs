using UnityEngine;

public class Erase : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Erase");
            SR.enabled = false;
            Collider.enabled = false;
        }
    }
}
