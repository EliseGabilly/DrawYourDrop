using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGroup : MonoBehaviour {

    #region Variables
    [SerializeField]
    private Items items;
    public GameObject Prefab { get; private set; }
    public float MinDiff { get; private set; }
    public float MaxDiff { get; private set; }
    public int Priority { get; private set; }

    public Queue<Item> ItemList { get; set; } = new Queue<Item>();
    public Item HighestItem { get; set; }
    public Vector3 LowestPos { get; set; }
    #endregion


    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
        Prefab = items.GO;
        MinDiff = items.MinDiff;
        MaxDiff = items.MaxDiff;
        Priority = items.Priority;
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));

        if (HighestItem.transform.position.y > positionTop.y + GameManager.Instance.WorldHeight * 1.5f) {
            SwitchHighestItemPosition();
        }
    }

    private void SwitchHighestItemPosition() {
        //change position to bottom
        LowestPos = new Vector3(
            Random.Range(-(GameManager.Instance.WorldWidth / 2) * 0.8f, (GameManager.Instance.WorldWidth / 2) * 0.8f), 
            LowestPos.y - GameManager.Instance.WorldHeight * Random.Range(MinDiff, MaxDiff), 
            0);
        HighestItem.transform.position = LowestPos;
        HighestItem.SR.enabled = true;
        HighestItem.Collider.enabled = true;
        //if reward reset velocity in case of magnet
        Rigidbody2D rb = HighestItem.GetComponent<Rigidbody2D>();
        if (rb != null) rb.velocity = Vector3.zero;
        //replace the highest item
        ItemList.Enqueue(HighestItem);
        HighestItem = ItemList.Dequeue();
    }

    public void EraseAction() {
        StartCoroutine(EraseWithDelay());
    }

    private IEnumerator EraseWithDelay() {
        for (int i = 0; i < 10; i++) {
            SwitchHighestItemPosition();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
