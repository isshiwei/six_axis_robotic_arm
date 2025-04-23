using HighlightPlus;
using UnityEngine;

public class RaycastFromCameraCenter : MonoBehaviour
{ 
    public Camera mainCamera;
    public float rayDistance = 100f;
    public IntroducePanel introducePanel;
    
    private HighlightEffect currentHighlight;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        // Draw the ray for visualization
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            HighlightEffect highlight = hit.collider.GetComponent<HighlightEffect>();
            if (highlight != null)
            {
                if (currentHighlight != null && currentHighlight != highlight)
                {
                    currentHighlight.highlighted = false;
                }
                
                highlight.highlighted = true;

                var introduceText = highlight.GetComponent<IntroduceText>();
                if (introduceText != null)
                    introducePanel.SetIntroduceText(introduceText.introduceTextValue);
                
                currentHighlight = highlight;
            }
            else if (currentHighlight != null)
            {
                currentHighlight.highlighted = false;
                currentHighlight = null;
                introducePanel.SetIntroduceText("");
            }
        }
        else
        {
            if (currentHighlight != null)
            {
                currentHighlight.highlighted = false;
                currentHighlight = null;
                introducePanel.SetIntroduceText("");
            }
        }
    }
}