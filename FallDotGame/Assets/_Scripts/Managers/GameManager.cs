using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private GameObject player;
    private Camera mainCamera;
    private Vector3 spawnPoint;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
        spawnPoint = player.transform.position;
    }

    private void Update() {
        if (!IsPlayerInFrame()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private bool IsPlayerInFrame() {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        float xRatio = screenPos.x / mainCamera.pixelWidth; //horizontal check
        float yRatio = screenPos.y / mainCamera.pixelHeight; //vertical chack
        return !(xRatio > 1.05f || xRatio < -.05f || yRatio > 1.05f || yRatio < -.05f);
    }

}
