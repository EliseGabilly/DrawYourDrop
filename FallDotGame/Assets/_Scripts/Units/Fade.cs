using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public void CallRealoadGame() {
        GameManager.Instance.GameOver();
    }

}
