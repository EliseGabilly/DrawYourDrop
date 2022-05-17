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

        ColorBlue = new Color32(72, 107, 250, 255);
        ColorPink = new Color32(250, 72, 222, 255);
        ColorRed = new Color32(250, 101, 72, 255);
        ColorYellow = new Color32(250, 214, 72, 255);
        ColorGreen = new Color32(72, 250, 96, 255);
        ColorWhite = Color.white;
        ColorBlack = Color.black;
        ColorBlueLight = new Color32(189, 212, 245, 255);
        ColorPinkLight = new Color32(244, 189, 245, 255);
        ColorRedLight = new Color32(245, 191, 189, 255);
        ColorYellowLight = new Color32(245, 228, 189, 255);
        ColorGreenLight = new Color32(189, 245, 193, 255);
    }
}
