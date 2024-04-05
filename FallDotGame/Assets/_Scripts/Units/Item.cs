using UnityEngine;

public abstract class Item : MonoBehaviour {

    #region Variables
    public SpriteRenderer SR { get; protected set; }
    public CircleCollider2D Collider { get; set; }

    public int Priority;
    #endregion

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected virtual void Awake() {
        SR = GetComponent<SpriteRenderer>();
        Collider = GetComponent<CircleCollider2D>();
    }

    protected void ReplaceOnOverlap(Item collision) {
        if((collision.gameObject.layer == 7 || gameObject.layer == 7) && Ball.Instance.IsMagnet) {
            // ignore this if it's a magnet reward
            return;
        }
        if (Priority > collision.Priority) {
            Collider.enabled = false;
            Vector2 pos = gameObject.transform.position;
            gameObject.transform.position = new Vector2(pos.x + Random.Range(-0.2f, 0.2f), pos.y - 0.2f);
            Collider.enabled = true;
        }
    }

}
