using UnityEngine;

public class Erase : Item {

    private ItemGroup obstacleGroup;

    protected override void Awake() {
        base.Awake();
        obstacleGroup = GameObject.FindWithTag("ObstacleGroup").GetComponent<ItemGroup>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SR.enabled = false;
            Collider.enabled = false;
            obstacleGroup.EraseAction();
            AudioSystem.Instance.PlayItem();
            GameManager.Instance.PickUpCount++;
        } else if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7) {
            ReplaceOnOverlap(collision.GetComponent<Item>());
        }
    }
}
