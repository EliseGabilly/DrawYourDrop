using UnityEngine;

public class ItemSpawnManager : Singleton<ItemSpawnManager> {

    #region Variables
    [SerializeField]
    private Transform itemParent;

    private int ItemNbSpawn = 30;
    #endregion

    protected void Start() {        
        InitialObjectSpawn();
        InitialPowerupSpawn();
    }

    private void InitialObjectSpawn() {
        ItemGroup[] itemGroups = itemParent.GetComponentsInChildren<ItemGroup>();
        GameObject go;

        //spawn reward, penalty and obstacles
        foreach (ItemGroup itemGroup in itemGroups) {
            GameObject prefab = itemGroup.Prefab;
            itemGroup.LowestPos = new Vector3(0, 0, 0);
            float margin = prefab.GetComponent<Item>() is Obstacle ? 0 : GameManager.Instance.WorldWidth*0.1f;
            
            for (int i = 0; i < ItemNbSpawn; i++) {
                itemGroup.LowestPos = new Vector3(
                    Random.Range(GameManager.Instance.WorldLeft + margin, GameManager.Instance.WorldRight - margin),
                    itemGroup.LowestPos.y - GameManager.Instance.WorldHeight * Random.Range(itemGroup.MinDiff, itemGroup.MaxDiff),
                    0);
                go = Instantiate(prefab, itemGroup.LowestPos, Quaternion.identity);
                go.transform.parent = itemGroup.gameObject.transform;
                go.name = go.name + i;
                Item itm = go.GetComponent<Item>();
                itm.Priority = itemGroup.Priority * ItemNbSpawn + i;
                itemGroup.ItemList.Enqueue(itm);
            }
            itemGroup.HighestItem = itemGroup.ItemList.Dequeue();
        }
    }

    private void InitialPowerupSpawn() {
        GameObject go;

        //spawn multiple of each power ups out of frame
        Vector3 positionTopLeftPlus = new Vector3(GameManager.Instance.WorldLeft + 10, GameManager.Instance.WorldHeight + 10, 10);
        ItemPowerUp powerUp = itemParent.GetComponentInChildren<ItemPowerUp>();
        foreach (Items items in powerUp.PowersUps) {
            GameObject obj = items.GO;
            for (int i = 0; i < ItemNbSpawn; i++) {
                go = Instantiate(obj, positionTopLeftPlus, Quaternion.identity);
                go.transform.parent = powerUp.gameObject.transform;
                go.name = go.name + i;
                ColorItem(go);
                Item itm = go.GetComponent<Item>();
                itm.Priority = items.Priority * ItemNbSpawn + i;
                powerUp.FreeItems.Add(go.GetComponent<Item>());
            }
        }

        //replace all of them randomly
        powerUp.SetFirstUsedItems(new Vector3(0, 0, 0));
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
