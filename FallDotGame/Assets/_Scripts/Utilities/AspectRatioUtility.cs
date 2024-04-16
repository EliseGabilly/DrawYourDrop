using UnityEngine;
 
public class AspectRatioUtility : MonoBehaviour {
    #region Variables
    private float scaleHeight;


    private float minAspect = 9.0f / 19.5f;
    private float maxAspect = 9.0f / 16.5f;

    #endregion
    
    void Awake() {
        float newScaleHeight = FindNewScaleHeight();
        Adjust(newScaleHeight);
    }

    void Update() {
        float newScaleHeight = FindNewScaleHeight();
        if(scaleHeight != newScaleHeight) {
            Adjust(newScaleHeight);
        }
    }

    private float FindNewScaleHeight(){
        float windowAspect = Screen.width / (float) Screen.height;
        float targetAspect = windowAspect;
        if (windowAspect<minAspect) {
            targetAspect = minAspect;
        } else if (windowAspect>maxAspect){
            targetAspect = maxAspect;
        }

        return windowAspect / targetAspect;
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
