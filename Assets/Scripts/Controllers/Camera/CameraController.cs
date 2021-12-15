using Controllers.Player;
using UnityEngine;

namespace Controllers.Camera
{
    public class CameraController : MonoBehaviour
    {
        private PlayerController _followPlayer;
        private Vector3 _cameraOffsetPosition = new Vector3(0f, 0f, -10f);

        private void Start()
        {
            _followPlayer = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            transform.position = _followPlayer.transform.position + _cameraOffsetPosition;
        }
    }
}
