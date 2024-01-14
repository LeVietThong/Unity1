using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup canvasGroup;
    public string nextSceneName;
    public float fadeDuration = 1f;
    public float delayBeforeFadeOut = 1f;

    private void Start()
    {
        // Đặt alpha của CanvasGroup là 0
        canvasGroup.alpha = 0;

        // Sử dụng DOTween để tạo hiệu ứng fade in
        canvasGroup.DOFade(1f, fadeDuration)
            .OnComplete(() =>
            {
                // Gọi hàm để delay trước khi fade out
                Invoke(nameof(FadeOut), delayBeforeFadeOut);
            });
    }

    private void FadeOut()
    {
        // Sử dụng DOTween để tạo hiệu ứng fade out
        canvasGroup.DOFade(0f, fadeDuration)
            .OnComplete(() =>
            {
                // Load scene tiếp theo sau khi fade out hoàn thành
                SceneManager.LoadScene(nextSceneName);
            });
    }
}
