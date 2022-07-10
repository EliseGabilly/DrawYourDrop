using UnityEngine;

public class CameraManager : MonoBehaviour {

    #region Variables
    private Camera mainCamera;
    private Transform playerTransform; 
    [SerializeField]
    private float movingSpeed = 1.2f;
    #endregion

    private void Awake() {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        if (GameManager.Instance.UseGravity) {
            Vector3 v3 = mainCamera.transform.position;
            v3.y = playerTransform.position.y + 2.4f; //TODO find magic value
            Vector3 playerPos = v3;
            Vector3 constMovePos = mainCamera.transform.position + Vector3.down * Time.deltaTime * movingSpeed;

            //Camera match either a constante movement or the player position if he is faster
            Vector3 lowestPos = playerPos.y < constMovePos.y ? playerPos : constMovePos;
            mainCamera.transform.position = lowestPos;
        }
    }
}
