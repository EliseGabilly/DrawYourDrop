using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject backgroundImg;
    [SerializeField]
    private Transform backgroundParent;

    private Queue<Transform> backgroundImgs = new Queue<Transform>();
    private Transform backgroundOnTop;
    private Camera mainCamera;
    private float worldHeight;
    private Vector3 position;

    private void Awake() {
        mainCamera = Camera.main;

        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth/2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        Vector3 positionBottom = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth/2, 0, -mainCamera.transform.position.z));
        worldHeight = positionTop.y - positionBottom.y;

        position = positionTop;
        position.z = 1;
        GameObject go;
        for(int i = 0; i<10; i++) {
            position.y -= worldHeight*Random.Range(0.1f, 0.6f);
            go = Instantiate(backgroundImg, position, Quaternion.identity) as GameObject;
            go.transform.parent = backgroundParent;
            backgroundImgs.Enqueue(go.transform);
        }
        backgroundOnTop = backgroundImgs.Dequeue();
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        if(backgroundOnTop.position.y > positionTop.y+1) {
            position.y -= worldHeight * Random.Range(0.1f, 0.6f);
            backgroundOnTop.position = position;
            backgroundImgs.Enqueue(backgroundOnTop);
            backgroundOnTop = backgroundImgs.Dequeue();
        }
    }
}
