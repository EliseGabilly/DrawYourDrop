using System;
using UnityEngine;

public class BallCloseTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Obstacle")) {
            AudioSystem.Instance.PlayHit();
            try {
                collision.gameObject.GetComponent<EdgeCollider2D>().isTrigger = false;
            } catch (Exception) { }
        }
    }

}
