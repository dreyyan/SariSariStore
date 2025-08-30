using UnityEngine;
using System.Collections;

public class RecordBookManager : MonoBehaviour
{
    public float enlargedScale = 2f;      // how big it gets when opened
    public float animationSpeed = 10f;    // speed of animation
    public bool isOpen = false;
    public bool isRecording = false;

    private RectTransform rectTransform;
    private Vector3 normalScale;
    private Vector3 bigScale;
    private Vector3 originalPosition;
    private Vector3 centerPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Save scales
        normalScale = Vector3.one;
        bigScale = Vector3.one * enlargedScale;

        // Save positions
        originalPosition = rectTransform.anchoredPosition;
        centerPosition = Vector3.zero; // center of screen

        // Start at normal size
        rectTransform.localScale = normalScale;
        isOpen = false;
    }

    public void OpenRecordBook()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateBook(bigScale, centerPosition));
    }

    public void CloseRecordBook()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateBook(normalScale, originalPosition));
    }

    IEnumerator AnimateBook(Vector3 targetScale, Vector3 targetPos)
    {
        while (Vector3.Distance(rectTransform.localScale, targetScale) > 0.01f ||
               Vector3.Distance(rectTransform.anchoredPosition, targetPos) > 0.1f)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, targetPos, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // Snap to exact values at the end
        rectTransform.localScale = targetScale;
        rectTransform.anchoredPosition = targetPos;
    }

    public void HandleRecordBook()
    {
        if (!isOpen)
        {
            OpenRecordBook();
            isOpen = true;
        }
        else
        {
            if (isRecording)
            {
                // optional recording logic
            }
            else
            {
                CloseRecordBook();
                isOpen = false;
            }
        }
    }
}
