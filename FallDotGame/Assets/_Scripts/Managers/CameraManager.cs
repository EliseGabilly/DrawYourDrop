using System;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    #region Variables
    private Camera mainCamera;
    private Transform playerTransform; 
    [SerializeField]
    private float BaseSpeed = 4; 
    [SerializeField]
    private float Acceleration; 
    private float MovingSpeed; 
    #endregion

    private void Awake() {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        if (GameManager.Instance.UseGravity) {
            // find player position 
            Vector3 v3 = mainCamera.transform.position;
            v3.y = playerTransform.position.y + 2.4f; //TODO find magic value
            Vector3 playerPos = v3;

            // find constant movement
            Acceleration = 8.3f / (1 + 100 * Mathf.Exp(-0.04f * GameManager.Instance.DistanceScore));
            MovingSpeed = BaseSpeed + Acceleration;
            Vector3 constMovePos = mainCamera.transform.position + Vector3.down * Time.deltaTime * MovingSpeed;

            //Camera match either the constant movement or the player position if he is faster
            Vector3 lowestPos = playerPos.y < constMovePos.y ? playerPos : constMovePos;
            mainCamera.transform.position = lowestPos;
        }
    }
}
