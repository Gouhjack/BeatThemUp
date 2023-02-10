using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] Vector3 _offset = Vector3.zero;
    [SerializeField] private Transform _target;
    [SerializeField] private BoxCollider2D _cameraBounds;
    [SerializeField] private bool _canFollow = true;

    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _cameraDimension.y = _camera.orthographicSize;
        _cameraDimension.x = _camera.orthographicSize * _camera.aspect;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!_canFollow)
        { return; }

        Vector3 followingPosition = _target.position + _offset;

        float minX = _cameraBounds.transform.position.x - _cameraBounds.size.x / 2 + _cameraDimension.x;
        float maxX = _cameraBounds.transform.position.x + _cameraBounds.size.x / 2 - _cameraDimension.x;
        followingPosition.x = Mathf.Clamp(followingPosition.x, minX, maxX);

        float minY = _cameraBounds.transform.position.y - _cameraBounds.size.y / 2 + _cameraDimension.y;
        float maxY = _cameraBounds.transform.position.y + _cameraBounds.size.y / 2 - _cameraDimension.y;
        followingPosition.y = Mathf.Clamp(followingPosition.y, minY, maxY);

        Vector3 currentVelocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, followingPosition, ref currentVelocity, Time.deltaTime * _moveSpeed);
            


    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    Camera _camera;
    Vector2 _cameraDimension;

    #endregion
}
