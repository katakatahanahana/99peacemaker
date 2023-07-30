using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideoInUI : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // VideoPlayer를 RawImage에 할당하여 동영상을 렌더링합니다.
        videoPlayer.targetTexture = RenderTexture.GetTemporary((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);

        // RawImage의 Texture를 VideoPlayer의 타겟 텍스처로 설정합니다.
        rawImage.texture = videoPlayer.targetTexture;

        // 동영상을 재생합니다.
        videoPlayer.Play();
    }
}
