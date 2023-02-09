using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _jumpHeight = 3f;
    [SerializeField] float _jumpDuration = 3f;
    [SerializeField] Animator _animator;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] int _maxJump = 2;
    [SerializeField] float _runSpeed = 10f;
    [SerializeField] int _hp = 20;
   

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

        GetMovement();

        Jump();

    }
    private void FixedUpdate()
    {
        _rb2D.velocity = _direction * Time.fixedDeltaTime * 50;
        //_direction.y = _rb2D.velocity.y;


        CharacterTurn();

    }
    #endregion

    #region Methods

    private void CharacterTurn()
    {
        if (_direction.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_direction.x > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    
    private void GetMovement()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal") * _moveSpeed, Input.GetAxisRaw("Vertical") * _moveSpeed);
        float maxValue = Mathf.Max(Mathf.Abs(_direction.x), Mathf.Abs(_direction.y));
        _animator.SetFloat("moveSpeedX", maxValue);
        _animator.SetBool("isRunning", false);
        if (Input.GetAxisRaw("Fire3") == 1)
        {
            _animator.SetBool("isRunning", true);
            _direction = new Vector2(Input.GetAxisRaw("Horizontal") * _runSpeed, Input.GetAxisRaw("Vertical") * _runSpeed);
        }

        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
            _animator.SetBool("isJumping", true);
            _animator.SetBool("land", false);

            //_animator.SetFloat("moveSpeedY", _direction.y);
            //Debug.Log("moveSpeedY");
        }
            if (_isJumping == true)
            {
                if (_jumpTimer < _jumpDuration)
                {

                    _jumpTimer += Time.deltaTime;

                    //progression / maximum
                    float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);

                    _graphics.localPosition = new Vector3(_graphics.localPosition.x, y * _jumpHeight, _graphics.localPosition.z);

                    _land = false;
                Debug.Log(Time.timeSinceLevelLoad);
                }
                else if (_jumpTimer >= _jumpDuration)
                {
                    _jumpTimer = 0f;
                    _isJumping = false;
                    _land = true;
                    _animator.SetBool("isJumping", false);
                    _animator.SetBool("land", true);
                    Debug.Log(Time.timeSinceLevelLoad);
                }
                // _animator.SetBool("Land", false);
                // _animator.SetBool("isJumping", false);
            }

            if (_land == true)
            {
                _isJumping = false;
                _animator.SetBool("isJumping", false);
            }
    }
    

#endregion

#region Private & Protected
    private Rigidbody2D _rb2D;
private Vector2 _direction;
private bool _isJumping;
private int _jumpNumber;
private bool _land;
public UnityEngine.Transform _graphics;
public float _jumpTimer = 0f;


    #endregion
}
