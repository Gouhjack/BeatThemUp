using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _jumpHeight = 3f;
    [SerializeField] float _jumpDuration = 3f;
    [SerializeField] Animator _animator;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] int _maxJump = 2;
   

    #endregion

    #region Unity LifeCycle
    private void Awake()
    {
        _graphics = transform.Find("GraphicsP1");
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        _direction.y = Input.GetAxisRaw("Vertical") * _moveSpeed;

        _animator.SetFloat("moveSpeedX", Mathf.Abs(_direction.x));

        if (Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
            if (_jumpTimer < _jumpDuration)
            {
                _jumpTimer += Time.deltaTime;

                //progression / maximum
                float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);

                _graphics.localPosition = new Vector3(_graphics.localPosition.x, y * _jumpHeight, _graphics.localPosition.z);

            }
            else
            {
                _jumpTimer = 0;
            }
            _animator.SetFloat("moveSpeedY", _direction.y);

        }
        




    }
    private void FixedUpdate()
    {
        _rb2D.velocity = _direction * Time.fixedDeltaTime * 50;
        //_direction.y = _rb2D.velocity.y;

        if (_direction.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_direction.x > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

    }
    #endregion

    #region Methods

    Transform _graphics;
    float _jumpTimer = 0f;

    #endregion

    #region Private & Protected

    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private bool _isJumping;
    private int _jumpNumber;

    #endregion
}
