using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Const { 

    public static Color SuccesColorDone;
    public static Color SuccesColorInProgress;

    static Const() {
        SuccesColorDone = Color.white;
        SuccesColorInProgress = Color.white;
        SuccesColorInProgress.a = 0.5f;
    }

}
