using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    [SerializeField]
    CanvasGroup menuCanvas = default;
    
    public void OptionstoMain()
    {
        StartCoroutine(FadeCanvaser(menuCanvas, 0f, 1f, 1f));
    }

    public static IEnumerator FadeCanvaser(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
    {
        var startTime = Time.time;
        var endTime = Time.time + duration;
        var elapsedTime = 0f;

        canvas.alpha = startAlpha;
        while (Time.time <= endTime)
        {
            elapsedTime = Time.time - startTime;
            var percentage = 1 / (duration / elapsedTime);
            if (startAlpha > endAlpha)
            {
                canvas.alpha = startAlpha - percentage;
            }
            else
            {
                canvas.alpha = startAlpha + percentage;
            }
            yield return new WaitForEndOfFrame();
        }
        canvas.alpha = endAlpha;
        
    }

}
