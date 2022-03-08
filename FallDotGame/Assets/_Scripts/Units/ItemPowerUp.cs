using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerUp : MonoBehaviour {

    #region Variables
    [SerializeField]
    private List<Items> powersUps;
    public List<GameObject> Prefabs { get; private set; }
    public float MinDiff { get; } = 0.5f;
    public float MaxDiff { get; } = 1.5f;

    public List<Item> FreeItems { get; set; } = new List<Item>();
    public List<Item> UsedItems { get; set; }
    public Vector3 LowestPos { get; set; }
    #endregion


    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;

        Prefabs = new List<GameObject>();
        foreach(Items itm in powersUps) {
            Prefabs.Add(itm.GO);
        }
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        foreach(Item usedItm in UsedItems) {
            if (usedItm.transform.position.y > positionTop.y + 1) {
                //if a power up is above screen then remove from UsedItems and add it to FreeItems
                UsedItems.Remove(usedItm);
                FreeItems.Add(usedItm);

                //place random power up in the bottom
                LowestPos = new Vector3(Random.Range(-(ItemSpawnManager.Instance.WorldWidth / 2) * 0.8f, (ItemSpawnManager.Instance.WorldWidth / 2) * 0.8f), LowestPos.y - ItemSpawnManager.Instance.WorldHeight * Random.Range(MinDiff, MaxDiff), 0);
                Item freeItm = GetRdmFreeItem();
                freeItm.transform.position = LowestPos;
                freeItm.SR.enabled = true;
                freeItm.Collider.enabled = true;
            }
        }
    }

    private Item GetRdmFreeItem() {
        Item itm = FreeItems[Random.Range(0, FreeItems.Count)];
        FreeItems.Remove(itm);
        UsedItems.Add(itm);
        return itm;
    }

}
