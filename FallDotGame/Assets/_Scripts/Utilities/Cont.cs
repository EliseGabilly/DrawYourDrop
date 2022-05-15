using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Const { 

    public static Color SuccesColorDone;
    public static Color SuccesColorInProgress;

    public static Color ColorBlue;
    public static Color ColorPink;
    public static Color ColorRed;
    public static Color ColorYellow;
    public static Color ColorGreen;
    public static Color ColorWhite;
    public static Color ColorBlack;
    public static Color ColorBlueLight;
    public static Color ColorPinkLight;
    public static Color ColorRedLight;
    public static Color ColorYellowLight;
    public static Color ColorGreenLight;

    static Const() {
        SuccesColorDone = Color.white;
        SuccesColorInProgress = Color.white;
        SuccesColorInProgress.a = 0.5f;

        ColorBlue = new Color(72, 107, 250);
        ColorPink = new Color(250, 72, 222);
        ColorRed = new Color(250, 101, 72);
        ColorYellow = new Color(250, 214, 72);
        ColorGreen = new Color(72, 250, 96);
        ColorWhite = Color.white;
        ColorBlack = Color.black;
        ColorBlueLight = new Color(189, 212, 245);
        ColorPinkLight = new Color(244, 189, 245);
        ColorRedLight = new Color(245, 191, 189);
        ColorYellowLight = new Color(245, 228, 189);
        ColorGreenLight = new Color(189, 245, 193);
    }
}
