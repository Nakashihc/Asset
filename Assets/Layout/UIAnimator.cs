using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIAnimator : MonoBehaviour
{
    public GameObject uiElement;
    public float animationDuration = 0.5f;

    private RectTransform uiRectTransform;

    public float posisiAwal = 0f;
    public float posisiAkhir = 0f;

    void Start()
    {
        if (uiElement != null)
        {
            uiRectTransform = uiElement.GetComponent<RectTransform>();
            uiElement.SetActive(false); // Initially hide the UI element
        }
    }

    void ShowUI()
    {
        uiElement.SetActive(true);
        StartCoroutine(SlideIn(uiRectTransform, animationDuration, posisiAwal, posisiAkhir));
    }

    void HideUI()
    {
        StartCoroutine(SlideOut(uiRectTransform, animationDuration, posisiAkhir, posisiAwal, () => uiElement.SetActive(false)));
    }

    System.Collections.IEnumerator SlideIn(RectTransform rectTransform, float duration, float startX, float endX)
    {
        Vector2 startPos = new Vector2(startX, rectTransform.anchoredPosition.y);
        Vector2 endPos = new Vector2(endX, rectTransform.anchoredPosition.y);

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
    }

    System.Collections.IEnumerator SlideOut(RectTransform rectTransform, float duration, float startX, float endX, UnityAction onComplete)
    {
        Vector2 startPos = new Vector2(startX, rectTransform.anchoredPosition.y);
        Vector2 endPos = new Vector2(endX, rectTransform.anchoredPosition.y);

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
        onComplete?.Invoke();
    }
}
