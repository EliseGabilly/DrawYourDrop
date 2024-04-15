using System.Collections;
using UnityEngine;

public class CameraManager : Singleton<CameraManager> {

    #region Variables
    private Camera mainCamera;
    private Transform playerTransform; 
    
    private float BaseSpeed = 4; 
    private float MaxAcceleration = 8; 

    private float Acceleration; 

    [SerializeField]
    private float MovingSpeed; 

    [SerializeField]
    private Animator animSlow;
    private float SlowCoefficient = 1f;
    private IEnumerator slowCoroutine;
    #endregion

    protected override void Awake() {
        base.Awake();
        mainCamera = Camera.main;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        slowCoroutine = SlowCountdown();
    }

    private void Update() {
        if (GameManager.Instance.UseGravity) {
            // find player position 
            Vector3 v3 = mainCamera.transform.position;
            v3.y = playerTransform.position.y + 2.4f; //TODO find magic value
            Vector3 playerPos = v3;

            // find constant movement
            FindMovingSpeed();
            Vector3 constMovePos = mainCamera.transform.position + Vector3.down * Time.deltaTime * MovingSpeed;

            //Camera match either the constant movement or the player position if he is faster
            Vector3 lowestPos = playerPos.y < constMovePos.y ? playerPos : constMovePos;
            mainCamera.transform.position = lowestPos;
        }
    }

    private void FindMovingSpeed() {
        float x = GameManager.Instance.DistanceScore;
        Acceleration = MaxAcceleration / (1 + 100 * Mathf.Exp(-0.04f * x));
        MovingSpeed = (BaseSpeed + Acceleration) * SlowCoefficient;
    }

    public void TakeSlow() {
        StopCoroutine(slowCoroutine);
        slowCoroutine = SlowCountdown();
        StartCoroutine(slowCoroutine);
    }

    private IEnumerator SlowCountdown() {
        SlowCoefficient = 0.5f;
        animSlow.SetTrigger("start");
        yield return new WaitForSeconds(5f);
        animSlow.SetTrigger("start");
        for(int i = 0; i<10; i++) {
            SlowCoefficient+= 0.05f;
            yield return new WaitForSeconds(0.5f);
        }
        EndSlow();
    }

    private void EndSlow() {
        animSlow.SetTrigger("end");
        SlowCoefficient = 1f;
    }
}
