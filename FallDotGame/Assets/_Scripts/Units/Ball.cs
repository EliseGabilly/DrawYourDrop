using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Singleton<Ball> {

    #region Variables
    [SerializeField]
    private Animator animShield;
    private bool isImune = false;
    [SerializeField]
    private Animator animMagnet;
    public bool IsMagnet { get; private set; } = false;
    [SerializeField]
    private Animator animBounce;
    public bool IsBounce { get; private set; } = false;
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

    public void TakeBounce() {
        StopCoroutine(BounceCountDown());
        StartCoroutine(BounceCountDown());
    }

    private IEnumerator BounceCountDown() {
        animBounce.SetTrigger("start");
        IsBounce = true;
        yield return new WaitForSeconds(6f);
        animBounce.SetTrigger("near_end");
        yield return new WaitForSeconds(3f);
        EndBounce();
    }

    private void EndBounce() {
        animBounce.SetTrigger("end");
        IsBounce = false;
    }

    public void WentOutOfFrame() {
        if (!IsBounce) {
            UiManager.Instance.FadeIn();
        } else {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-transform.position.normalized.x*40, rb.velocity.y);
        }
    }
}
