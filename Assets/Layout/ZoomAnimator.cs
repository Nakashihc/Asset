using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ZoomAnimator : MonoBehaviour
{
    public GameObject uiElement;
    public float animationDuration = 0.5f;
    public float delayDuration = 2.0f;

    private RectTransform uiRectTransform;

    public Vector3 scaleAwal = new Vector3(0f, 0f, 1f); // Initial scale (invisible)
    public Vector3 scaleAkhir = new Vector3(1f, 1f, 1f); // Final scale (default scale)
    public Vector3 scaleOvershoot = new Vector3(1.2f, 1.2f, 1f); // Overshoot scale

    void Start()
    {
        if (uiElement != null)
        {
            uiRectTransform = uiElement.GetComponent<RectTransform>();
            uiElement.SetActive(false); // Initially hide the UI element
        }
    }

    public void ShowUI()
    {
        uiElement.SetActive(true);
        StartCoroutine(DelayedHide(uiRectTransform, animationDuration, scaleAwal, scaleAkhir, scaleOvershoot));
    }

    private System.Collections.IEnumerator DelayedHide(RectTransform rectTransform, float duration, Vector3 startScale, Vector3 endScale, Vector3 overshootScale)
    {
        yield return StartCoroutine(PopIn(rectTransform, duration, startScale, endScale, overshootScale));
        yield return new WaitForSeconds(delayDuration);
        yield return StartCoroutine(PopOut(rectTransform, duration, endScale, startScale, () => uiElement.SetActive(false)));
    }

    private System.Collections.IEnumerator PopIn(RectTransform rectTransform, float duration, Vector3 startScale, Vector3 endScale, Vector3 overshootScale)
    {
        float elapsedTime = 0;
        float halfDuration = duration / 2;

        // Scale up to overshoot scale
        while (elapsedTime < halfDuration)
        {
            rectTransform.localScale = Vector3.Lerp(startScale, overshootScale, (elapsedTime / halfDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0;

        // Scale down to final scale
        while (elapsedTime < halfDuration)
        {
            rectTransform.localScale = Vector3.Lerp(overshootScale, endScale, (elapsedTime / halfDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = endScale;
    }

    private System.Collections.IEnumerator PopOut(RectTransform rectTransform, float duration, Vector3 startScale, Vector3 endScale, UnityAction onComplete)
    {
        float elapsedTime = 0;
        float halfDuration = duration / 2;

        // Scale down to zero scale
        while (elapsedTime < duration)
        {
            rectTransform.localScale = Vector3.Lerp(startScale, endScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = endScale;
        onComplete?.Invoke();
    }
}
