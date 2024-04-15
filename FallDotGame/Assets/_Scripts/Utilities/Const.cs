using UnityEngine;

public static class Const { 

    public static Color ColorSelected;
    public static Color ColorUnselected;

    public static Color ColorBlue; //pick up
    public static Color ColorRed; // penalty
    public static Color ColorGreen; // bonus

    public static Color ColorBackgroundLight; // background
    public static Color ColorBackgroundMid; // stone and grid
    public static Color ColorBackgroundDark; // pipes


    public static Color ColorGrey;
    public static Color ColorBlack;

    static Const() {
        ColorSelected = new Color32(56, 56, 56, 255);
        ColorUnselected = new Color32(56, 56, 56, 125);

        ColorBlue = new Color32(64, 96, 222, 255);
        ColorRed = new Color32(217, 41, 70, 255);
        ColorGreen = new Color32(63, 140, 21, 255);

        ColorBackgroundLight = new Color32(230, 245, 255, 255);
        ColorBackgroundMid = new Color32(210, 232, 255, 255);
        ColorBackgroundDark = new Color32(191, 220, 255, 255);

        ColorGrey = new Color32(88, 88, 88, 255);
        ColorBlack = Color.black;
    }
}
