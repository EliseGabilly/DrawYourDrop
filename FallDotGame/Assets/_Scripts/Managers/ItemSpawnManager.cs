using UnityEngine;

public class ItemSpawnManager : Singleton<ItemSpawnManager> {

    #region Variables
    [SerializeField]
    private Transform itemParent;

    private Camera mainCamera;
    public float WorldHeight { get; private set; }
    public float WorldWidth { get; private set; }
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

            for (int i = 0; i < 10; i++) {
                itemGroup.LowestPos = new Vector3(Random.Range(-(WorldWidth / 2) * 0.8f, (WorldWidth / 2) * 0.8f), itemGroup.LowestPos.y - WorldHeight * Random.Range(itemGroup.MinDiff, itemGroup.MaxDiff), 0);
                go = Instantiate(prefab, itemGroup.LowestPos, Quaternion.identity) as GameObject;
                go.transform.parent = itemGroup.gameObject.transform;
                itemGroup.ItemList.Enqueue(go.GetComponent<Item>());
            }
            itemGroup.HighestItem = itemGroup.ItemList.Dequeue();
        }

        //spawn two of each power ups out of frame
        ItemPowerUp powerUp = itemParent.GetComponentInChildren<ItemPowerUp>();
        foreach(GameObject itm in powerUp.Prefabs) {
            for (int i = 0; i < 3; i++) {
                go = Instantiate(itm, positionTopLeft, Quaternion.identity) as GameObject;
                go.transform.parent = powerUp.gameObject.transform;
                powerUp.FreeItems.Add(go.GetComponent<Item>());
            }
        }
        //replace four of them randomly
        powerUp.SetFirstUsedItems(new Vector3(0, positionTopLeft.y - WorldHeight / 2, 0));
    }
}
