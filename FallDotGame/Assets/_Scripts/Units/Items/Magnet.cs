using UnityEngine;

public class Magnet : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Magnet");
            collision.gameObject.GetComponent<Player>().TakeMagnet();
            SR.enabled = false;
            Collider.enabled = false;
        } 
    }
}
