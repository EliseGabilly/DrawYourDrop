using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

    public SpriteRenderer SR { get; protected set; }
    public CircleCollider2D Collider { get; protected set; }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    private void Awake() {
        SR = GetComponent<SpriteRenderer>();
        Collider = GetComponent<CircleCollider2D>();
    }
}
