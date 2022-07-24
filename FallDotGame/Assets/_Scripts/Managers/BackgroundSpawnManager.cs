using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    private GameObject backgroundImg;
    [SerializeField]
    private Transform backgroundParent;

    [SerializeField]
    private Sprite[] backgrounds;

    private readonly Queue<GameObject> backgroundImgs = new Queue<GameObject>();
    private GameObject backgroundOnTop;
    private Camera mainCamera;
    private float worldHeight;
    private Vector3 position;
    private int layerOrder = 0;

    private float H, S, V;
    #endregion

    private void Start() {

        mainCamera = Camera.main;

        Color baseColor = Player.Instance.colorBackground;
        Color.RGBToHSV(baseColor, out H, out S, out V);

        Vector3 positionTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        Vector3 positionBottomRight = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0, -mainCamera.transform.position.z));
        float worldWidth = positionBottomRight.x - positionTopLeft.x ;
        worldHeight = positionTopLeft.y - positionBottomRight.y;

        float scaleWidth = worldWidth / backgrounds[0].bounds.size.x * 1.1f;
        float scaleHeight = worldHeight / backgrounds[0].bounds.size.y *1.1f;

        position = new Vector3(position.x, position.y+1.5f*worldHeight, 0.1f);
        GameObject go;
        for(int i = 0; i<12; i++) {
            position.y -= worldHeight*Random.Range(0.1f, 0.6f);
            go = Instantiate(backgroundImg, position, Quaternion.identity) as GameObject;
            go.transform.SetParent(backgroundParent);
            go.transform.localScale = new Vector3(scaleWidth, scaleHeight, 1);

            Restyle(go);

            backgroundImgs.Enqueue(go);
        }
        backgroundOnTop = backgroundImgs.Dequeue();
    }

    private void Restyle(GameObject go) {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();

        sr.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        Color color = Random.ColorHSV(H - 0.02f, H + 0.02f, S - 0.02f, S + 0.02f, V - 0.02f, V + 0.02f);
        sr.color = color;

        sr.sortingOrder = layerOrder;
        layerOrder++;
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        if(backgroundOnTop.transform.position.y > positionTop.y + worldHeight*1.5f) {
            position.y -= worldHeight * Random.Range(0.1f, 0.6f);
            backgroundOnTop.transform.position = position;
            Restyle(backgroundOnTop);

            backgroundImgs.Enqueue(backgroundOnTop);
            backgroundOnTop = backgroundImgs.Dequeue();
        }
    }
}
