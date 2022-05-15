using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : Singleton<Ball> {

    #region Variables
    [SerializeField]
    private GameObject goShield;
    private Animator animShield;
    private bool isImune = false;
    [SerializeField]
    private GameObject goMagnet;
    private Animator animMagnet;
    public bool IsMagnet { get; private set; } = false;
    [SerializeField]
    private GameObject goBounce;
    private Animator animBounce;
    public bool IsBounce { get; private set; } = false;
    #endregion

    protected override void Awake() {
        base.Awake();
        animShield = goShield.GetComponent<Animator>();
        animMagnet = goMagnet.GetComponent<Animator>();
        animBounce = goBounce.GetComponent<Animator>();

        SpriteRenderer srShield = goShield.GetComponent<SpriteRenderer>();
        srShield.color = Player.Instance.colorMagic;
        SpriteRenderer srMagnet = goMagnet.GetComponent<SpriteRenderer>();
        srMagnet.color = Player.Instance.colorMagic;
        Image imgBounceA = goBounce.GetComponentsInChildren<Image>()[0];
        Image imgBounceB = goBounce.GetComponentsInChildren<Image>()[1];
        imgBounceA.color = Player.Instance.colorMagic;
        imgBounceB.color = Player.Instance.colorMagic;

        SpriteRenderer srBall = GetComponent<SpriteRenderer>();
        srBall.color = Player.Instance.colorBall;
    }

    public void TakeDamage() {
        if (!isImune) GameManager.Instance.GameOver();
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
            GameManager.Instance.GameOver();
        } else {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-transform.position.normalized.x*40, rb.velocity.y);
        }
    }
}
