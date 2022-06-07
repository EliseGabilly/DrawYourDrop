using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private readonly Color[] colorsMagic = new Color[]{ Const.ColorBlue, Const.ColorPink, Const.ColorRed, Const.ColorYellow, Const.ColorGreen};
    private int countMagic = 0;
    [SerializeField]
    private Image colorBall;
    private readonly Color[] colorsBall = new Color[] { Const.ColorWhite, Const.ColorBlack, Const.ColorBlue, Const.ColorRed, Const.ColorGreen };
    private int countBall = 0;
    [SerializeField]
    private Image colorBg;
    private readonly Color[] colorsBg = new Color[] { Const.ColorBlueLight, Const.ColorPinkLight, Const.ColorRedLight, Const.ColorYellowLight, Const.ColorGreenLight };
    private int countBg = 0;
    #endregion

    private void Start() {
        countMagic = FindColorIndex(Player.Instance.colorMagic, colorsMagic);
        countBall = FindColorIndex(Player.Instance.colorBall, colorsBall);
        countBg = FindColorIndex(Player.Instance.colorBackground, colorsBg);

        float volumeMusic = Player.Instance.volumeMusic;
        float volumeSound = Player.Instance.volumeSound;
        musicSlider.value = volumeMusic;
        soundSlider.value = volumeSound;
        AudioSystem.Instance.SetSourcesVolume(musicSlider.value, soundSlider.value);

        SaveAndDisplay();
    }

    private void SaveAndDisplay() {
        Player.Instance.ChangeOptionsColors(colorsBall[countBall], colorsMagic[countMagic], colorsBg[countBg]);

        colorMagic.color = Player.Instance.colorMagic;
        colorBall.color = Player.Instance.colorBall;
        colorBg.color = Player.Instance.colorBackground;
    }

    private int FindColorIndex(Color color, Color[] colors) {
        for (int i = 0; i < colors.Length; i++) {
            if (colors[i].Equals(color)) {
                return i;
            }
        }
        return 0;
    }

    public void ChangeMagicColor(int change) {
        AudioSystem.Instance.PlayClic();
        countMagic += change;
        countMagic = countMagic >= colorsMagic.Length ? 0 : countMagic;
        countMagic = countMagic < 0 ? colorsMagic.Length-1 : countMagic;

        colorMagic.color = colorsMagic[countMagic];
    }

    public void ChangeBgColor(int change) {
        AudioSystem.Instance.PlayClic();
        countBg += change;
        countBg = countBg >= colorsBg.Length ? 0 : countBg;
        countBg = countBg < 0 ? colorsBg.Length-1 : countBg;

        colorBg.color = colorsBg[countBg];
    }

    public void ChangeBallColor(int change) {
        AudioSystem.Instance.PlayClic();
        countBall += change;
        countBall = countBall >= colorsBall.Length ? 0 : countBall;
        countBall = countBall < 0 ? colorsBall.Length-1 : countBall;

        colorBall.color = colorsBall[countBall];
    }

    public void ReloadApperance() {
        SaveAndDisplay();
        AudioSystem.Instance.PlayClic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangVolume() {
        Player.Instance.ChangeOptionsMusic(musicSlider.value, soundSlider.value);
        AudioSystem.Instance.SetSourcesVolume(musicSlider.value, soundSlider.value);
    }
}
