using UnityEngine;

public class Bounce : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Bounce");
            collision.gameObject.GetComponent<Player>().TakeBounce();
            SR.enabled = false;
            Collider.enabled = false;            
        }
    }
}
