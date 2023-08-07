using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    private void OnEnable()
    {
        EventManager.Instance.onPlatformPassed += MoveToNextPlatformPosition;
    }
    private void OnDisable()
    {
        EventManager.Instance.onPlatformPassed -= MoveToNextPlatformPosition;
    }
    private void MoveToNextPlatformPosition(IPlatform platform)
    {
        transform.DOMove(platform.PlatformTransform.position + cameraOffset, 0.5f);
    }
}
