using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _offsetCameraY;
    [SerializeField] private float _offsetCameraX;

    private Vector3 _position;
    private void Update()
    {
        CameraMovement();
    }
    private void CameraMovement()
    {
        _position = _player.position;
        _position.z = -10f;
        _position.x += _offsetCameraX;
        _position.y += _offsetCameraY;
        
        transform.position = Vector3.Lerp(transform.position, _position, _offsetCameraY);
    }
}
