using System.Collections;
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

    private IEnumerator shieldCoroutine;
    private IEnumerator magnetCoroutine;
    private IEnumerator bounceCoroutine;
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

        shieldCoroutine = ShieldCountDown();
        magnetCoroutine = MagnetCountDown();
        bounceCoroutine = BounceCountDown();
    }

    public void TakeDamage() {
        if (!isImune) GameManager.Instance.GameOver("Took damage");
        else EndShield();
    }

    public void TakeShield() {
        StopCoroutine(shieldCoroutine);
        shieldCoroutine = ShieldCountDown();
        StartCoroutine(shieldCoroutine);
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
        StopCoroutine(magnetCoroutine);
        magnetCoroutine = MagnetCountDown();
        StartCoroutine(magnetCoroutine);
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
        StopCoroutine(bounceCoroutine);
        bounceCoroutine = BounceCountDown();
        StartCoroutine(bounceCoroutine);
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
            GameManager.Instance.GameOver("Out of frame");
        } else {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-transform.position.normalized.x*40, rb.velocity.y);
        }
    }
}
