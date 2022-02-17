using UnityEngine;

public abstract class Item : MonoBehaviour {

    #region Variables
    public SpriteRenderer SR { get; protected set; }
    public CircleCollider2D Collider { get; protected set; }
    #endregion

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    private void Awake() {
        SR = GetComponent<SpriteRenderer>();
        Collider = GetComponent<CircleCollider2D>();
    }
}
