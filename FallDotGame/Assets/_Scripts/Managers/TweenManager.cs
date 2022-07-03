using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenManager : Singleton<TweenManager> {

    [SerializeField]
    private GameObject score;

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
