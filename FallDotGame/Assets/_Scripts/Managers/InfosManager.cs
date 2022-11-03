using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;

public class InfosManager : MonoBehaviour {

    #region variable
    [SerializeField]
    private Image rulesImg;
    [SerializeField]
    private Image runesImg;
    [SerializeField]
    private Image infoImg;

    [SerializeField]
    private Text[] txtBoxes;

    [Serializable]
    public enum InfoPage {Rules=0, Runes=1, Info=2};
    private int currentPage;

    #endregion

    private void Start() {
        currentPage = -1;
        SelectContent(0);
        StartCoroutine(SetTextSize());
    }

    private IEnumerator SetTextSize() {
        yield return null;

        int sameSizeCounter = 0;
        int minSize = txtBoxes[0].cachedTextGenerator.fontSizeUsedForBestFit;
        
        for (int i = 0; i < txtBoxes.Length; i++) {
            if (minSize > txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit) {
                minSize = txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit;
            } else if (minSize == txtBoxes[i].cachedTextGenerator.fontSizeUsedForBestFit) {
                sameSizeCounter++;
            }
        }

        if (sameSizeCounter != txtBoxes.Length) {
            for (int i = 0; i < txtBoxes.Length; i++) {
                txtBoxes[i].resizeTextMaxSize = minSize;
            }
        }
    }

    public void SelectContent(int pageSelected) {
        if (currentPage == pageSelected) {
            return;
        }

        InfoPage infoPage = InfoPage.Rules;
        switch (pageSelected) {
            case 0:
                infoPage = InfoPage.Rules;
                break;
            case 1:
                infoPage = InfoPage.Runes;
                break;
            case 2:
                infoPage = InfoPage.Info;
                break;
        }

        rulesImg.color = infoPage == InfoPage.Rules ? Const.ColorSelected : Const.ColorUnselected;
        runesImg.color = infoPage == InfoPage.Runes ? Const.ColorSelected : Const.ColorUnselected;
        infoImg.color = infoPage == InfoPage.Info ? Const.ColorSelected : Const.ColorUnselected;

        TweenManager.Instance.SlideInfoRules(infoPage == InfoPage.Rules);
        TweenManager.Instance.SlideInfoRunes(infoPage == InfoPage.Runes);
        TweenManager.Instance.SlideInfoCredit(infoPage == InfoPage.Info);

        currentPage = pageSelected;
    }

}
