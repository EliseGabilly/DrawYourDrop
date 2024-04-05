using System;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    #region Variables
    private Camera mainCamera;
    private Transform playerTransform; 
    [SerializeField]
    private float MaxAcceleration = 8.5f; 
    [SerializeField]
    private float BaseSpeed = 4; 
    [SerializeField]
    private float StartAccelerationDistance = 25; 
    private float AccelerationCoefficient = 0.05f; 
    [SerializeField]
    private float Acceleration; 
    [SerializeField]
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
            Acceleration = Mathf.Min(Mathf.Max( AccelerationCoefficient * (GameManager.Instance.DistanceScore - StartAccelerationDistance), 0), MaxAcceleration);
            MovingSpeed = BaseSpeed + Acceleration;
            Vector3 constMovePos = mainCamera.transform.position + Vector3.down * Time.deltaTime * MovingSpeed;

            //Camera match either the constant movement or the player position if he is faster
            Vector3 lowestPos = playerPos.y < constMovePos.y ? playerPos : constMovePos;
            mainCamera.transform.position = lowestPos;
        }
    }
}
