using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenManager : Singleton<TweenManager> {

    [SerializeField]
    private GameObject go;

    private void Start() {
        //go.transform.DOScale(0.5f, 1);
        //DOTween.Init();

    }

    public void Pulse() {
        go.transform
            .DOScale(1.4f, 0.2f)
            .SetEase(Ease.InOutQuad)
            .OnComplete(
                () => go.transform
                   .DOScale(1, 0.2f)
                   .SetEase(Ease.InOutQuad)
            );
    }

}
