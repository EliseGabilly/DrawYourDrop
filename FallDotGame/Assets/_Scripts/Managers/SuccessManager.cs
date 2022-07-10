using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SuccessManager : Singleton<SuccessManager> {

    #region Variables
    [Header("Last game stats")]
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

    [Header("General stats")]
    [SerializeField]
    private Text best_score;
    [SerializeField]
    private Text best_bonus;
    [SerializeField]
    private Text best_distance;

    [SerializeField]
    private Text game_count;
    [SerializeField]
    private Text average;
    [SerializeField]
    private Text total_power_up;
    [SerializeField]
    private Text total_lines;
    #endregion

    public void LoadSuccess() {
        // Last game
        score.text = string.Format("Last score\n{0}", Player.Instance.lastScore.ToString());
        bonus.text = string.Format("{0}\nBonus", Player.Instance.lastBonusScore.ToString());
        distance.text = string.Format("{0}\nDistance", Player.Instance.lastDistanceScore.ToString());

        death.text = string.Format("Death reason : {0}", Player.Instance.highDistanceScore.ToString());
        clock.text = string.Format("Time played : {0}", Player.Instance.highDistanceScore.ToString());
        power_up.text = string.Format("Pick up : {0}", Player.Instance.highDistanceScore.ToString());
        lines.text = string.Format("Line drawns : {0}", Player.Instance.highDistanceScore.ToString());

        Text[] txtLastGame = new Text[] {bonus, distance, death, clock, power_up, lines};
        StartCoroutine(SetTextSize(txtLastGame));

        // Genaral
        best_score.text = string.Format("Personal best\n{0}", Player.Instance.highScore.ToString());
        best_bonus.text = string.Format("{0}\nBonus", Player.Instance.highBonusScore.ToString());
        best_distance.text = string.Format("{0}\nDistance", Player.Instance.highDistanceScore.ToString());

        game_count.text = string.Format("Game played : {0}", Player.Instance.highDistanceScore.ToString());
        average.text = string.Format("Average : {0}", Player.Instance.highDistanceScore.ToString());
        total_power_up.text = string.Format("Pick up : {0}", Player.Instance.highDistanceScore.ToString());
        total_lines.text = string.Format("Line drawns : {0}", Player.Instance.highDistanceScore.ToString());

        Text[] txtGeneral = new Text[] {game_count, best_bonus, best_distance, game_count, average, total_power_up, total_lines};
        StartCoroutine(SetTextSize(txtGeneral));
    }

    private IEnumerator SetTextSize(Text[] txtBoxes) {
        yield return null;

        int minSize = 1000;

        for (int i = 0; i < txtBoxes.Length; i++) {
            if (minSize > txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit) {
                minSize = txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit;
            }
        }
        
        for (int i = 0; i < txtBoxes.Length; i++) {
            txtBoxes[i].resizeTextMaxSize = minSize;
        }
    }

}
