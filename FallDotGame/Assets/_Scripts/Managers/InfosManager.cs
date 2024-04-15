using UnityEngine;
using UnityEngine.UI;
using System;

public class InfosManager : Singleton<InfosManager> {

    #region Variables
    [Header("Text fields")]
    [SerializeField]
    private Text title;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text summeryTxt;
    [SerializeField]
    private Text musicTxt;
    [SerializeField]
    private Text thanksTxt;

    [Header("Buttons")]
    [SerializeField]
    private Image eraser;
    [SerializeField]
    private Image shield;
    [SerializeField]
    private Image magnet;
    [SerializeField]
    private Image bounce;
    [SerializeField]
    private Image slow;
    [SerializeField]
    private Image penalty;
    [SerializeField]
    private Image bonus;


    [Header("Text")]
    private int textSize;
    private string DEFAULT_TITLE = "Collectables";
    private string DEFAULT_TXT = "Select a collectible to see more information about his use.";
    private string ERASER_TITLE = "Eraser";
    private string ERASER_TXT = "The eraser remove approaching obstacles, making it briefly easier to move through the drop.";
    private string MAGNET_TITLE = "Magnet";
    private string MAGNET_TXT = "The magnet attracts bonuses to you for a few seconds, making it easier to collect points.";
    private string BOUNCE_TITLE = "Bounce";
    private string BOUNCE_TXT = "The wall gives a temporary immunity to side screen exit, while active the ball will bounce.";
    private string SHIELD_TITLE = "Shield";
    private string SHIELD_TXT = "The shield gives immunity for one penalty, a mistake can happen so you have to anticipate. ";
    private string SLOW_TITLE = "Slow";
    private string SLOW_TXT = "This power-up give you ten seconds to catch up to a slower camera, make good use of this time. ";
    private string BONUS_TITLE = "Bonus";
    private string BONUS_TXT = "You want to score more points? Collect the bonuses along the way to earn 10 extra points.";
    private string PENALTY_TITLE = "Penalty";
    private string PENALTY_TXT = "Be careful ! The path is full of pitfalls, a penalty could put an end to your fall.";
    #endregion

    public void LoadInfos() {
        if (textSize == 0) {
            SetTextSize();
        }

        title.text = DEFAULT_TITLE;
        text.text = DEFAULT_TXT;
    }

    private void SetTextSize() {
        int minSize = (int) Math.Floor(title.cachedTextGenerator.fontSizeUsedForBestFit * 0.8f);

        Text[] txtHolder = new Text[] {text, summeryTxt, musicTxt, thanksTxt};
        foreach(Text holder in txtHolder) {
            if (minSize > holder.cachedTextGenerator.fontSizeUsedForBestFit) {
                minSize = holder.cachedTextGenerator.fontSizeUsedForBestFit;
            }
        }
        string[] texts = new string[]{DEFAULT_TXT, ERASER_TXT, SHIELD_TXT, MAGNET_TXT, BOUNCE_TXT, PENALTY_TXT, BONUS_TXT, SLOW_TXT};
        foreach (string txt in texts) {
            text.text = txt;
            if (minSize > text.cachedTextGenerator.fontSizeUsedForBestFit) {
                minSize = text.cachedTextGenerator.fontSizeUsedForBestFit;
            }
        }

        textSize = minSize;
        foreach (Text holder in txtHolder) {
            holder.resizeTextMaxSize = minSize;
        }
        title.resizeTextMaxSize = minSize*2;
    }

    public void SelectItem(string item) {
        Image[] imgs = new Image[] { eraser, magnet, bounce, shield, bonus, penalty, slow};
        foreach (Image img in imgs) {
            img.color = Const.ColorGrey;
        }

        switch (item) {
            case "eraser":
                title.text = ERASER_TITLE;
                text.text = ERASER_TXT;
                eraser.color = Color.black;
                break;
            case "magnet":
                title.text = MAGNET_TITLE;
                text.text = MAGNET_TXT;
                magnet.color = Color.black;
                break;
            case "bounce":
                title.text = BOUNCE_TITLE;
                text.text = BOUNCE_TXT;
                bounce.color = Color.black;
                break;
            case "shield":
                title.text = SHIELD_TITLE;
                text.text = SHIELD_TXT;
                shield.color = Color.black;
                break;
            case "slow":
                title.text = SLOW_TITLE;
                text.text = SLOW_TXT;
                slow.color = Color.black;
                break;
            case "bonus":
                title.text = BONUS_TITLE;
                text.text = BONUS_TXT;
                bonus.color = Color.black;
                break;
            case "penalty":
                title.text = PENALTY_TITLE;
                text.text = PENALTY_TXT;
                penalty.color = Color.black;
                break;

            default:
                throw new Exception();
        }
    }
}
