using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPenalty : Item {

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SR.enabled = false;
            Collider.enabled = false;
        }
    }

}
