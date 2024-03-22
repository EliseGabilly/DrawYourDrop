using System.Collections.Generic;
using UnityEngine;

public class ItemPowerUp : MonoBehaviour {

    #region Variables
    [SerializeField]
    public List<Items> PowersUps;
    public float MinDiff { get; } = 0.5f;
    public float MaxDiff { get; } = 1.5f;

    public List<Item> FreeItems { get; set; } = new List<Item>();
    public List<Item> UsedItems { get; set; } = new List<Item>();
    public Vector3 LowestPos { get; set; }
    #endregion


    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        foreach(Item usedItm in UsedItems) {
            if (usedItm.transform.position.y > positionTop.y + 1) {
                //if a power up is above screen then remove from UsedItems and add it to FreeItems
                UsedItems.Remove(usedItm);
                FreeItems.Add(usedItm);

                //place random power up in the bottom
                LowestPos = new Vector3(
                    Random.Range(-(GameManager.Instance.WorldWidth / 2) * 0.8f, (GameManager.Instance.WorldWidth / 2) * 0.8f),
                    LowestPos.y - GameManager.Instance.WorldHeight * Random.Range(MinDiff, MaxDiff),
                    0);
                Item freeItm = GetRdmFreeItem();
                freeItm.transform.position = LowestPos;
                freeItm.SR.enabled = true;
                freeItm.Collider.enabled = true;

                break;
            }
        }
    }

    private Item GetRdmFreeItem() {
        Item itm = FreeItems[Random.Range(0, FreeItems.Count)];
        FreeItems.Remove(itm);
        UsedItems.Add(itm);
        return itm;
    }

    public void SetFirstUsedItems(Vector3 pos) {
        LowestPos = pos;
        for(int i=0; i<4; i++) {
            Item itm = GetRdmFreeItem();
            LowestPos = new Vector3(
                Random.Range(-(GameManager.Instance.WorldWidth / 2) * 0.8f, (GameManager.Instance.WorldWidth / 2) * 0.8f),
                LowestPos.y - GameManager.Instance.WorldHeight * Random.Range(MinDiff, MaxDiff),
                0);
            itm.transform.position = LowestPos;
            itm.SR.enabled = true;
            itm.Collider.enabled = true;
        }
    }
}
