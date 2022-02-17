using UnityEngine;

public class Fade : MonoBehaviour {

    public void CallRealoadGame() {
        GameManager.Instance.GameOver();
    }

}
