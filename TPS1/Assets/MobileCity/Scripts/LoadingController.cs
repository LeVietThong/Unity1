using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingController : MonoBehaviour
{
    public Slider loadingSlider;
    public Text loadingText; 
    public float loadingTime = 5f;
    public string nextSceneName;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    public float delayBeforeFadeOut = 5.5f;

    private void Start()
    {
        // Bắt đầu Coroutine để chạy màn loading
        StartCoroutine(StartLoading());
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

    private IEnumerator StartLoading()
    {
        float elapsedTime = 0f;

        while (elapsedTime < loadingTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / loadingTime;

            // Cập nhật giá trị và phần trăm hoàn thành của Slider
            loadingSlider.value = progress;
            loadingText.text = (progress * 100f).ToString("0") + "%";

            yield return null;
        }
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
