using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

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
        Player playerInstance = Player.Instance;

        //Last game
        score.text = string.Format("Last score\n{0}", playerInstance.lastScore.ToString());
        bonus.text = string.Format("{0}\nBonus", playerInstance.lastBonusScore.ToString());
        distance.text = string.Format("{0}\nDistance", playerInstance.lastDistanceScore.ToString());

        death.text = string.Format("Death reason : {0}", playerInstance.deathReason);
        clock.text = string.Format("Time played : {0}", playerInstance.timePlayed.ToString());
        power_up.text = string.Format("Pick up : {0}", playerInstance.pickUp.ToString());
        lines.text = string.Format("Line drawns : {0}", playerInstance.linesDrawn.ToString());

        // Genaral
        best_score.text = string.Format("Personal best\n{0}", playerInstance.highScore.ToString());
        best_bonus.text = string.Format("{0}\nBonus", playerInstance.highBonusScore.ToString());
        best_distance.text = string.Format("{0}\nDistance", playerInstance.highDistanceScore.ToString());

        game_count.text = string.Format("Game played : {0}", playerInstance.gamePlayed.ToString());
        string avg = playerInstance.scoreHistory.Count == 0 ? "" : playerInstance.scoreHistory.Average().ToString();
        average.text = string.Format("Average : {0}", avg);
        total_power_up.text = string.Format("Pick up : {0}", playerInstance.ttPickUp.ToString());
        total_lines.text = string.Format("Line drawns : {0}", playerInstance.ttLinesDrawn.ToString());

        StartCoroutine(SetTextSize());
    }

    private IEnumerator SetTextSize() {
        yield return null; 
        Text[] txtBoxes = new Text[] { bonus, distance, death, clock, power_up, lines, best_bonus, best_distance, game_count, average, total_power_up, total_lines };

        int minSize = 1000;

        for (int i = 0; i < txtBoxes.Length; i++) {
            if (minSize > txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit) {
                minSize = txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit;
            }
        }

        for (int i = 0; i < txtBoxes.Length; i++) {
            txtBoxes[i].resizeTextMaxSize = minSize/2;
        }
    }

}
