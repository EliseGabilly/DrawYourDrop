using UnityEngine;

public static class Const { 

    public static Color ColorSelected;
    public static Color ColorUnselected;

    public static Color ColorBlue;
    public static Color ColorRed;
    public static Color ColorGreen;
    public static Color ColorBlueLight;

    public static Color ColorWhite;
    public static Color ColorBlack;

    static Const() {
        ColorSelected = new Color32(56, 56, 56, 255);
        ColorUnselected = new Color32(56, 56, 56, 125);

        ColorBlue = new Color32(72, 107, 250, 255);
        ColorRed = new Color32(250, 101, 72, 255);
        ColorGreen = new Color32(72, 250, 96, 255);
        ColorBlueLight = new Color32(189, 212, 245, 255);

        ColorWhite = Color.white;
        ColorBlack = Color.black;

    }
}
