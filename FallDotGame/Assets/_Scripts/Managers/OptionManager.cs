using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    private Image soundOn;
    [SerializeField]
    private Image soundLow;
    [SerializeField]
    private Image soundOff;
    #endregion

    private void Start() {
        soundOff.enabled = Player.Instance.musicLevel == 0;
        soundLow.enabled = Player.Instance.musicLevel == 1;
        soundOn.enabled = Player.Instance.musicLevel == 2;
    }

    public void ChangeVolume() {
        Player.Instance.ChangeOptionsMusic();

        soundOff.enabled = Player.Instance.musicLevel == 0;
        soundLow.enabled = Player.Instance.musicLevel == 1;
        soundOn.enabled = Player.Instance.musicLevel == 2;
    }
}
