using UnityEngine;

public class Obstacle : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        //obstacle have no trigger
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7) {
            ReplaceOnOverlap(collision.GetComponent<Item>());
        }
    }
}
