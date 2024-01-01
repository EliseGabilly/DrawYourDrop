using UnityEngine;

public class ItemSpawnManager : Singleton<ItemSpawnManager> {

    #region Variables
    [SerializeField]
    private Transform itemParent;

    private Camera mainCamera;
    public float WorldHeight { get; private set; }
    public float WorldWidth { get; private set; }

    private int ItemNbSpawn = 10;
    #endregion

    protected override void Awake() {
        base.Awake();

        mainCamera = Camera.main;

        ItemGroup[] itemGroups = itemParent.GetComponentsInChildren<ItemGroup>();
        Vector3 positionTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        Vector3 positionBottomRight = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -mainCamera.transform.position.z));
        WorldHeight = positionTopLeft.y - positionBottomRight.y;
        WorldWidth = positionTopLeft.x - positionBottomRight.x;

        GameObject go;
        //spawn reward, penalty and obstacles
        foreach (ItemGroup itemGroup in itemGroups) {
            GameObject prefab = itemGroup.Prefab;
            itemGroup.LowestPos = new Vector3(0, positionTopLeft.y - WorldHeight / 2, 0);

            for (int i = 0; i < ItemNbSpawn; i++) {
                itemGroup.LowestPos = new Vector3(Random.Range(-(WorldWidth / 2) * 0.8f, (WorldWidth / 2) * 0.8f), itemGroup.LowestPos.y - WorldHeight * Random.Range(itemGroup.MinDiff, itemGroup.MaxDiff), 0);
                go = Instantiate(prefab, itemGroup.LowestPos, Quaternion.identity) as GameObject;
                go.transform.parent = itemGroup.gameObject.transform;
                go.name = go.name + i;
                Item itm = go.GetComponent<Item>();
                itm.Priority = itemGroup.Priority * ItemNbSpawn + i;
                itemGroup.ItemList.Enqueue(itm);
            }
            itemGroup.HighestItem = itemGroup.ItemList.Dequeue();
        }

        //spawn multiple of each power ups out of frame
        Vector3 positionTopLeftPlus = new Vector3(positionTopLeft.x+10, positionTopLeft.y+10, positionTopLeft.z+10);
        ItemPowerUp powerUp = itemParent.GetComponentInChildren<ItemPowerUp>();
        foreach(Items items in powerUp.PowersUps) {
            GameObject obj = items.GO;
            for (int i = 0; i < ItemNbSpawn; i++) {
                go = Instantiate(obj, positionTopLeftPlus, Quaternion.identity) as GameObject;
                go.transform.parent = powerUp.gameObject.transform;
                go.name = go.name + i;
                ColorItem(go);
                Item itm = go.GetComponent<Item>();
                itm.Priority = items.Priority * ItemNbSpawn + i;
                powerUp.FreeItems.Add(go.GetComponent<Item>());
            }
        }
        //replace four of them randomly
        powerUp.SetFirstUsedItems(new Vector3(0, positionTopLeft.y - WorldHeight / 2, 0));
    }

    private void ColorItem(GameObject go) {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        if(sr != null) {
            sr.color = Const.ColorBlue;
        } else {
            SpriteRenderer[] srList = go.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer aSr in srList){
                aSr.color = Const.ColorBlue;
            }
        }
    }
}
