using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    private float lineSeparationDistance = .2f;
    [SerializeField]
    private float lineWidth = .1f;
    [SerializeField]
    private Color lineColor = Color.black;
    [SerializeField]
    private int lineCapVertices = 5;
    [SerializeField]
    private Transform linesContainer;

    readonly List<GameObject> lines;
    List<Vector2> currentLine;
    LineRenderer currentLinerRenderer;
    private EdgeCollider2D currentLineEdgeCollider;
    private Material material;

    private bool isDrawing = false;

    private Camera mainCamera;
    #endregion

    private void Awake() {
        mainCamera = Camera.main;
        material = new Material(Shader.Find("Particles/Standard Unlit"));
    }

    private void Update() {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) {
            StartCoroutine(nameof(Drawing));
        } else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0)) {
            isDrawing = false;
        }
    }

    private IEnumerator Drawing() {
        isDrawing = true;
        StartLine();
        while (isDrawing) {
            AddPoint(GetCurrentWorldPoitn());
            yield return null;
        }
        EndLine();
    }

    private void StartLine() {
        //Init line
        currentLine = new List<Vector2>();
        GameObject goLine = new GameObject { name = "Line" };
        goLine.transform.parent = linesContainer;
        currentLinerRenderer = goLine.AddComponent<LineRenderer>();

        //Set values
        currentLinerRenderer.positionCount = 0;
        currentLinerRenderer.startWidth = lineWidth;
        currentLinerRenderer.endWidth = lineWidth;
        currentLinerRenderer.numCapVertices = lineCapVertices;
        currentLinerRenderer.material = material;
        currentLinerRenderer.startColor = lineColor;
        currentLinerRenderer.endColor = lineColor;
        currentLinerRenderer.sortingOrder = 20;
    }

    private Vector2 GetCurrentWorldPoitn() {
        Vector3 screenPosDepth = Input.mousePosition;
        screenPosDepth.z = -mainCamera.transform.position.z; // Give it camera depth
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(screenPosDepth);
        return mousePos;
    }

    private void AddPoint(Vector2 point) {
        if (PlacePoint(point)) {
            currentLine.Add(point);
            currentLinerRenderer.positionCount++;
            currentLinerRenderer.SetPosition(currentLinerRenderer.positionCount - 1, point);
        }
    }

    private bool PlacePoint(Vector2 point) {
        return currentLine.Count == 0 || Vector2.Distance(point, currentLine[currentLine.Count - 1]) > lineSeparationDistance;
    }

    private void EndLine() {
        currentLineEdgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        currentLineEdgeCollider.edgeRadius = lineWidth / 2;
        currentLineEdgeCollider.SetPoints(currentLine);
    }
}
