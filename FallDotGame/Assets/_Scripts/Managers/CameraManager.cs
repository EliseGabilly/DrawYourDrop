using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private Camera mainCamera;
    private Transform playerTransform; 
    [SerializeField]
    private float movingSpeed = 1.2f;

    private void Awake() {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(playerTransform.position);
        float yRatio = screenPos.y / mainCamera.pixelHeight; //vertical check
        if( yRatio < .4f) { 
            //if on the botom part of the screen match camera to player position
            Vector3 v3 = mainCamera.transform.position;
            v3.y = playerTransform.position.y+2.4f; //TODO find magic value
            mainCamera.transform.position = v3;
        } else {
            //else constant move
            mainCamera.transform.position += Vector3.down * Time.deltaTime * movingSpeed;
        }
    }
}
