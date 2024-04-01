using UnityEngine;

public class AnimManager : StaticInstance<AnimManager> {

    #region Variable
    [SerializeField]
    private Animator fade;
    #endregion

    public void FadeIn() {
        fade.Play("fade_in");
    }

}
