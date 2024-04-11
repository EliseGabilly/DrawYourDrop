using UnityEngine;
 
public class AspectRatioUtility : MonoBehaviour {
    
    private float scaleHeight;
    
    void Awake() {
        float targetAspect = 9.0f / 16.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float newScaleHeight = windowAspect / targetAspect;
        Adjust(newScaleHeight);
    }

    void Update() {
        float targetAspect = 9.0f / 16.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float newScaleHeight = windowAspect / targetAspect;
        if(scaleHeight != newScaleHeight) {
            Adjust(newScaleHeight);
        }
    }
 
    public void Adjust(float newScaleHeight) {
        scaleHeight = newScaleHeight;
 
        Camera camera = GetComponent<Camera>();
 
        if (scaleHeight < 1.0f) {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
 
            camera.rect = rect;
        } else {
            float scaleWidth = 1.0f / scaleHeight;
 
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
 
            camera.rect = rect;
        }
        
        GameManager.Instance.AdjustWorldSize();
    }
}
