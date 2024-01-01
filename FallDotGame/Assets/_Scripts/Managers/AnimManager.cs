using UnityEngine;
using System.Collections;

public class AnimManager : StaticInstance<AnimManager> {

    #region Variable
    [SerializeField]
    private Animator fade;
    #endregion

    public IEnumerator FadeIn() {
        fade.Play("fade_in");

        while (!fade.IsInTransition(0)) {
            yield return null;
        }
    }

}
