using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SuccessManager : Singleton<SuccessManager> {

    #region Variables
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text bonus;
    [SerializeField]
    private Text distance;

    [SerializeField]
    private Text death;
    [SerializeField]
    private Text clock;
    [SerializeField]
    private Text power_up;
    [SerializeField]
    private Text lines;

    private Text[] txtBoxes;
    #endregion

    public void LoadSuccess() {
        score.text = string.Format("Last score\n{0}", Player.Instance.highScore.ToString());
        bonus.text = string.Format("{0}\nBonus", Player.Instance.highBonusScore.ToString());
        distance.text = string.Format("{0}\nDistance", Player.Instance.highDistanceScore.ToString());

        death.text = string.Format("Death reason : {0}", Player.Instance.highDistanceScore.ToString());
        clock.text = string.Format("Time played : {0}", Player.Instance.highDistanceScore.ToString());
        power_up.text = string.Format("Pick up : {0}", Player.Instance.highDistanceScore.ToString());
        lines.text = string.Format("Line drawns : {0}", Player.Instance.highDistanceScore.ToString());

        txtBoxes = new Text[] {bonus, distance, death, clock, power_up, lines};
        StartCoroutine(SetTextSize());
    }

    private IEnumerator SetTextSize() {
        yield return null;

        int minSize = 1000;

        for (int i = 0; i < txtBoxes.Length; i++) {
            if (minSize > txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit)
                minSize = txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit;
        }

        for (int i = 0; i < txtBoxes.Length; i++) {
            txtBoxes[i].resizeTextMaxSize = minSize;
        }
    }

}
