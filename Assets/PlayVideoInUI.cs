using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideoInUI : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // VideoPlayer�� RawImage�� �Ҵ��Ͽ� �������� �������մϴ�.
        videoPlayer.targetTexture = RenderTexture.GetTemporary((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);

        // RawImage�� Texture�� VideoPlayer�� Ÿ�� �ؽ�ó�� �����մϴ�.
        rawImage.texture = videoPlayer.targetTexture;

        // �������� ����մϴ�.
        videoPlayer.Play();
    }
}
