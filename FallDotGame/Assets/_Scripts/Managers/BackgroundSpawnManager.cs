using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    private GameObject backgroundImg;
    [SerializeField]
    private Transform backgroundParent;

    private Queue<GameObject> backgroundImgs = new Queue<GameObject>();
    private GameObject backgroundOnTop;
    private Camera mainCamera;
    private float worldHeight;
    private Vector3 position;
    private int layerOrder = 0;
    #endregion

    private void Awake() {
        mainCamera = Camera.main;

        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth/2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        Vector3 positionBottom = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth/2, 0, -mainCamera.transform.position.z));
        worldHeight = positionTop.y - positionBottom.y;

        position = new Vector3(position.x, position.y+1.5f*worldHeight, 5);
        GameObject go;
        for(int i = 0; i<10; i++) {
            position.y -= worldHeight*Random.Range(0.1f, 0.6f);
            go = Instantiate(backgroundImg, position, Quaternion.identity) as GameObject;
            go.transform.SetParent(backgroundParent);
            
            Resize(go);
            FullRestyle(go);

            backgroundImgs.Enqueue(go);
        }
        backgroundOnTop = backgroundImgs.Dequeue();
    }

    private void Resize(GameObject go) {
        float worldWidth = mainCamera.pixelWidth;
        float worldHeight = mainCamera.pixelHeight;
        float scale = 40 * worldWidth / worldHeight;
        go.transform.localScale = new Vector2(scale, scale*2);
    }

    private void FullRestyle(GameObject go) {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        float scale = go.transform.localScale.x;

        sr.material.shader = Shader.Find("Disolve");
        sr.material.SetFloat("_NoiseScale", scale);
        sr.material.SetFloat("_NoiseStrenght", scale/8);
        sr.material.SetFloat("_EdgeHeight", scale/80);

        Restyle(go);
    }

    private void Restyle(GameObject go) {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();

        sr.material.shader = Shader.Find("Disolve");
        sr.material.SetFloat("_CutOffHeight", position.y);
        sr.material.SetFloat("_Shift", Random.Range(-100, 100));
        sr.material.SetColor("_ColorShift", Random.ColorHSV(0.9f, 1f, 0.9f, 1f, 0.9f, 1f));
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
