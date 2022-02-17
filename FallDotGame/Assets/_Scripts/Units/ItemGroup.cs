using System.Collections.Generic;
using UnityEngine;

public class ItemGroup : MonoBehaviour {

    #region Variables
    [SerializeField]
    private Items items;
    public GameObject Prefab { get; private set; }
    public float MinDiff { get; private set; }
    public float MaxDiff { get; private set; }

    public Queue<Item> ItemList { get; set; } = new Queue<Item>();
    public Item HighestItem { get; set; }
    public Vector3 LowestPos { get; set; }
    #endregion


    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
        Prefab = items.GO;
        MinDiff = items.MinDiff;
        MaxDiff = items.MaxDiff;
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        if (HighestItem.transform.position.y > positionTop.y+1) {
            //change position to bottom
            LowestPos = new Vector3(Random.Range(-(ItemSpawnManager.Instance.WorldWidth/2)*0.8f, (ItemSpawnManager.Instance.WorldWidth / 2) * 0.8f), LowestPos.y - ItemSpawnManager.Instance.WorldHeight * Random.Range(MinDiff, MaxDiff), 0);
            HighestItem.transform.position = LowestPos;
            HighestItem.SR.enabled = true;
            HighestItem.Collider.enabled = true;
            //replace the highest item
            ItemList.Enqueue(HighestItem);
            HighestItem = ItemList.Dequeue();
        }
    }

}
