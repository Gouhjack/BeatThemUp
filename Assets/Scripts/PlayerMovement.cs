using JetBrains.Annotations;
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
    
    [SerializeField] float _runSpeed = 10f;
    
   

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

        //Jump();

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
        else if (Input.GetAxisRaw("Fire3") == 0) _animator.SetBool("isRunning", false);


    }

  //  void Jump()
  //  {
  //      if (Input.GetButton("Jump"))
  //      {
  //          _isJumping = true;
  //          _animator.SetBool("isJumping", true);
  //      }
  //      if (_isJumping)
  //      {
  //          if (_jumpTimer < _jumpDuration)
  //          {
  //              _jumpTimer += Time.deltaTime;
  //              float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);
  //              _graphics.localPosition = new Vector3(_graphics.localPosition.x, y * _jumpHeight, _graphics.localPosition.z);
  //          }
  //          else if (_jumpTimer >= _jumpDuration)
  //          {
  //              _jumpTimer = 0f;
  //              _isJumping = false;
  //              _animator.SetBool("isJumping", false);
  //          }
  //      }
  //  }


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
