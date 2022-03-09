using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {

    #region Variables

    [SerializeField]
    private Animator animShield;
    private bool isImune = false;
    [SerializeField]
    private Animator animMagnet;
    public bool IsMagnet { get; private set; } = false;
    #endregion

    public void TakeDamage() {
        if (!isImune) UiManager.Instance.FadeIn();
        else EndShield();
    }

    public void TakeShield() {
        StopCoroutine(ShieldCountDown());
        StartCoroutine(ShieldCountDown());
    }

    private IEnumerator ShieldCountDown() {
        isImune = true;
        animShield.SetBool("isActive", isImune);
        yield return new WaitForSeconds(10f);
        EndShield();
    }

    private void EndShield() {
        isImune = false;
        animShield.SetBool("isActive", isImune);
    }

    public void TakeMagnet() {
        StopCoroutine(MagnetCountDown());
        StartCoroutine(MagnetCountDown());
    }

    private IEnumerator MagnetCountDown() {
        IsMagnet = true;
        animMagnet.SetBool("isActive", IsMagnet);
        yield return new WaitForSeconds(10f);
        EndMagnet();
    }

    private void EndMagnet() {
        IsMagnet = false;
        animMagnet.SetBool("isActive", isImune);
    }

}
