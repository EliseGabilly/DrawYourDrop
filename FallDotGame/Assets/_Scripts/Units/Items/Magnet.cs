using UnityEngine;

public class Magnet : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameManager.Instance.AddToInGameMagnetCount();
            collision.gameObject.GetComponent<Ball>().TakeMagnet();
            SR.enabled = false;
            Collider.enabled = false;
        } 
    }
}
