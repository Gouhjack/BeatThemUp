using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _jumpHeight = 3f;
    [SerializeField] float _jumpDuration = 3f;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _graphics = transform.Find("GraphicsP1");
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {

    }


    private void Update()
    {
        Jump();
    }

    #endregion

    #region Methods

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            _isJumping = true;
            _animator.SetBool("isJumping", true);
        }
        if (_isJumping)
        {
            if (_jumpTimer < _jumpDuration)
            {
                _jumpTimer += Time.deltaTime;
                float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);
                _graphics.localPosition = new Vector3(_graphics.localPosition.x, y * _jumpHeight, _graphics.localPosition.z);
            }
            else if (_jumpTimer >= _jumpDuration)
            {
                _jumpTimer = 0f;
                _isJumping = false;
                _animator.SetBool("isJumping", false);
            }
        }
    }

    #endregion

    #region Private & Protected

    private Transform _graphics;
    private float _jumpTimer;
    private bool _isJumping = false;
    private Animator _animator;

    #endregion
}
