using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    private GameObject backgroundObject;
    [SerializeField]
    private Transform backgroundParent;
    [SerializeField]
    private Sprite[] backgrounds;
    [SerializeField]
    private GameObject pipeObject;
    [SerializeField]
    private Transform pipeParent;
    [SerializeField]
    private Sprite[] pipes;

    private readonly Queue<GameObject> backgroundImgs = new Queue<GameObject>();
    private GameObject backgroundOnTop;
    private float backgroundPreviousHeight = 0;
    private Vector3 backgroundPosition;

    private readonly Queue<GameObject> pipeImgs = new Queue<GameObject>();
    private GameObject pipeOnTop;
    private float pipePreviousHeight = 0;
    private Vector3 pipePosition;

    private Camera mainCamera;
    private int layerOrder = 0;
    Color baseColor;
    #endregion

    private void Start() {
        mainCamera = Camera.main;

        baseColor = Const.ColorBlueLight;

        InitialBackgroundSpawn();
        InitialPipeSpawn();
    }

    private void InitialBackgroundSpawn() {
        GameObject go;
        backgroundPosition = new Vector3(backgroundPosition.x, backgroundPosition.y + 1.5f * GameManager.Instance.WorldHeight, 5);

        for (int i = 0; i < 40; i++) {
            Sprite sprite = backgrounds[Random.Range(0, backgrounds.Length)];
            float height = sprite.bounds.size.y / 2;
            backgroundPosition.y -= height + backgroundPreviousHeight + Random.Range(1, 5);
            backgroundPosition.x = Random.Range(GameManager.Instance.WorldLeft, GameManager.Instance.WorldRight);
            go = Instantiate(backgroundObject, backgroundPosition, Quaternion.identity) as GameObject;
            go.transform.SetParent(backgroundParent);

            Restyle(go, sprite);

            backgroundImgs.Enqueue(go);
            backgroundPreviousHeight = height;
        }
        backgroundOnTop = backgroundImgs.Dequeue();
    }

    private void InitialPipeSpawn() {
        GameObject go;
        pipePosition = new Vector3(pipePosition.x, pipePosition.y + 1.5f * GameManager.Instance.WorldHeight, 2.5f);

        for (int i = 0; i < 20; i++) {
            Sprite sprite = pipes[Random.Range(0, pipes.Length)];
            float height = sprite.bounds.size.y / 2;
            pipePosition.y -= height + pipePreviousHeight + Random.Range(1, 5);
            go = Instantiate(pipeObject, pipePosition, Quaternion.identity) as GameObject;
            go.transform.SetParent(pipeParent);

            Restyle(go, sprite, true);

            pipeImgs.Enqueue(go);
            pipePreviousHeight = height;
        }
        pipeOnTop = pipeImgs.Dequeue();
    }

    private void Restyle(GameObject go, Sprite sprite, bool isDarker = false) {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();

        sr.sprite = sprite;
        Color color = baseColor;
        if (isDarker) {
            color = new Color(baseColor.r - 0.1f, baseColor.g - 0.1f, baseColor.b - 0.1f);
        }
        sr.color = color;

        sr.sortingOrder = layerOrder;
        layerOrder++;
    }

    private void Update() {
        Vector3 positionTop = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight, -mainCamera.transform.position.z));
        if(backgroundOnTop.transform.position.y > positionTop.y + GameManager.Instance.WorldHeight * 1.5f) {
            UpdateBackground();
        }
        
        if(pipeOnTop.transform.position.y > positionTop.y + GameManager.Instance.WorldHeight * 1.5f) {
            UpdatePipe();
        }
    }

    private void UpdateBackground() {
        Sprite sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        float height = sprite.bounds.size.y / 2;
        backgroundPosition.y -= height + backgroundPreviousHeight + Random.Range(1, 5);
        backgroundPosition.x = Random.Range(GameManager.Instance.WorldLeft, GameManager.Instance.WorldRight);
        backgroundOnTop.transform.position = backgroundPosition;

        Restyle(backgroundOnTop, sprite);

        backgroundImgs.Enqueue(backgroundOnTop);
        backgroundOnTop = backgroundImgs.Dequeue();
        backgroundPreviousHeight = height;
    }

    private void UpdatePipe() {
        Sprite sprite = pipes[Random.Range(0, pipes.Length)];
        float height = sprite.bounds.size.y / 2;
        pipePosition.y -= height + pipePreviousHeight + Random.Range(1, 5);
        pipeOnTop.transform.position = pipePosition;

        Restyle(pipeOnTop, sprite, true);

        pipeImgs.Enqueue(pipeOnTop);
        pipeOnTop = pipeImgs.Dequeue();
        pipePreviousHeight = height;
    }
}
