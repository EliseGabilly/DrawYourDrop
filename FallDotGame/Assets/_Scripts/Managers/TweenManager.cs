using UnityEngine;
using DG.Tweening;

public class TweenManager : Singleton<TweenManager> {

    #region Variable
    [SerializeField]
    private GameObject success_last;
    [SerializeField]
    private GameObject success_general;
    [SerializeField]
    private GameObject score;

    private bool isSwitch = true;
    private float width;
    #endregion

    protected override void Awake() {
        base.Awake();
        width = success_last.GetComponent<RectTransform>().rect.width;
        success_general.transform
            .DOMoveX(2 * width, 0)
            .SetEase(Ease.InOutQuad);
    }

    public void SlideSuccess() {
        success_last.transform
            .DOMoveX(isSwitch ? -2*width : 0, 0.4f)
            .SetEase(Ease.InOutQuad);
        success_general.transform
            .DOMoveX(isSwitch ? 0 : 2*width, 0.4f)
            .SetEase(Ease.InOutQuad);
        isSwitch = !isSwitch;
    }

    public void ScorePulseEffect() {
        score.transform
            .DOScale(1.4f, 0.2f)
            .SetEase(Ease.InOutQuad)
            .OnComplete(
                () => score.transform
                   .DOScale(1, 0.2f)
                   .SetEase(Ease.InOutQuad)
            );
    }

    public void ScoreRotateEffect() {
        score.transform
            .DORotate(new Vector3(0, 0, 30), 0.2f)
            .SetEase(Ease.InOutQuad)
            .OnComplete(
                () => score.transform
                    .DORotate(new Vector3(0, 0, -30), 0.4f)
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(
                        () => score.transform
                            .DORotate(new Vector3(0, 0, 0), 0.2f)
                            .SetEase(Ease.InOutQuad)
                        )
            );
    }
}
