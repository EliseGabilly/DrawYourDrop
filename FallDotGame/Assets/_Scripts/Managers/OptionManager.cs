using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    #region Variables
    [Header("Music")]
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundSlider;

    [Header("Colors")]
    [SerializeField]
    private Image colorMagic;
    private Color[] colorsMagic = new Color[]{ Const.ColorBlue, Const.ColorPink, Const.ColorRed, Const.ColorYellow, Const.ColorGreen};
    private int countMagic = 0;
    [SerializeField]
    private Image colorBall;
    private Color[] colorsBall = new Color[] { Const.ColorWhite, Const.ColorBlack, Const.ColorBlue, Const.ColorRed, Const.ColorGreen };
    private int countBall = 0;
    [SerializeField]
    private Image colorBg;
    private Color[] colorsBg = new Color[] { Const.ColorBlueLight, Const.ColorPinkLight, Const.ColorRedLight, Const.ColorYellowLight, Const.ColorGreenLight };
    private int countBg = 0;
    #endregion

    private void Start() {
        countMagic = findColorIndex(Player.Instance.colorMagic, colorsMagic);
        countBall = findColorIndex(Player.Instance.colorBall, colorsBall);
        countBg = findColorIndex(Player.Instance.colorBackground, colorsBg);

        Player.Instance.ChangeOptions(musicSlider.value, soundSlider.value, colorsBall[countBall], colorsMagic[countMagic], colorsBg[countBg]);
        colorMagic.color = Color.white;
        colorBall.color = Player.Instance.colorBall;
        colorBg.color = Player.Instance.colorBackground;
    }

    private int findColorIndex(Color color, Color[] colors) {
        for (int i = 0; i < colors.Length; i++) {
            if (colors[i].Equals(color)) {
                return i;
            }
        }
        return 0;
    }

}
