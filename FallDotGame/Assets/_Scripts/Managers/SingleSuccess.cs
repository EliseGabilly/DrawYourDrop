using UnityEngine;
using UnityEngine.UI;

public class SingleSuccess : MonoBehaviour {

    #region Variables
    [SerializeField]
    private Success success;

    [SerializeField]
    private Text description;
    public Text Description { get => description; }
    [SerializeField]
    private Text completionTxt;
    public Text CompletionTxt { get => completionTxt; }
    [SerializeField]
    private Image img;
    [SerializeField]
    private Image completion1;
    [SerializeField]
    private Image completion2;
    [SerializeField]
    private Image completion3;
    [SerializeField]
    private Image completion4;
    #endregion

    private void Awake() {
        img.sprite = success.Illustration;
        description.text = success.Description;
        completionTxt.text = string.Format("{0} / {1}", 42, success.CompletionStep4);
    }

    public void ToggleView() {
        img.enabled = !img.enabled;
        description.enabled = !description.enabled;
        completionTxt.enabled = !completionTxt.enabled;
    }

    public void SetCompletionTo(int successScore) {
        int nextStep = 0;
        img.color = Const.SuccesColorInProgress;
        completion1.color = Const.SuccesColorInProgress;
        completion2.color = Const.SuccesColorInProgress;
        completion3.color = Const.SuccesColorInProgress;
        completion4.color = Const.SuccesColorInProgress;
        if (successScore <= 0) {
            return;
        }
        if (successScore >= success.CompletionStep1) {
            nextStep = success.CompletionStep2;
            completion1.color = Const.SuccesColorDone;
            img.color = Const.SuccesColorDone;
        }
        if (successScore >= success.CompletionStep2) {
            nextStep = success.CompletionStep3;
            completion2.color = Const.SuccesColorDone;
        }
        if (successScore >= success.CompletionStep3) {
            nextStep = success.CompletionStep4;
            completion3.color = Const.SuccesColorDone;
        }
        if (successScore >= success.CompletionStep4) {
            completion4.color = Const.SuccesColorDone;
        }
        completionTxt.text = string.Format("{0} / {1}", successScore, nextStep);
    }

}
