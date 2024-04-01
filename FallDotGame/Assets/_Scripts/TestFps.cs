using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestFps : MonoBehaviour {

    private int FramesPerSec;
    private float frequency = 1.0f;
    [SerializeField]
    private Text fps;

    void Start() {
        StartCoroutine(FPS());
    }

    private IEnumerator FPS() {
        for (; ; ) {
            // Capture frame-per-second
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            // Display it
            fps.text = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
        }
    }
}
