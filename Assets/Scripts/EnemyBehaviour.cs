using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    IDLE,
    WALK,
    ATTACK,
    DEAD
}
public class EnemyBehaviour : MonoBehaviour
{
    #region Expose
    
    [Header("IA Enemy")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _speed;
    [SerializeField]
    [Tooltip("Limite prêt du Player avant d'attaquer")]
    private float _limitNearTarget;
    [SerializeField]
    [Tooltip("Temps avant d'attaquer")]
    private float _waitingTimeBeforeAttack;
    [SerializeField]
    [Tooltip("Temps d'attaque")]
    private float _attackduration;
    [SerializeField]
    [Tooltip("Collider coup de point")]
    private GameObject _hitBox;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {

    }
    void Start()
    {
        
        TransitionToState(EnemyState.IDLE);
        _moveTarget = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        OnStateUpadate();

    }
    
    private void FixedUpdate()
    {
        //Tourner le personnage dans la bonne direction
        Flip();

    }
    
  // private void OnCollisionEnter2D(Collision2D collision)
  // {
  //     if (collision.gameObject.CompareTag("Attack"))
  //     {
  //          Debug.Log("Ma vie = " + _healthpoint);
  //         _healthpoint--;
  //          Debug.Log("Je perd des point de vie");
  //         if (_healthpoint == 0)
  //         {
  //              Debug.Log("Je suis mort");
  //             TransitionToState(EnemyState.DEAD);
  //             SpawnItemAfterDeath();
  //             Destroy(gameObject);
  //         }
  //     }
  // }
    #endregion
    
    #region Methods

    private void OnStateEnter()
    {
          switch (_currentState)
          {
              case EnemyState.IDLE:
                  _attackTimer = 0;
                  break;
              case EnemyState.WALK:
                  _animator.SetBool("IsWalking", true);
                  break;
              case EnemyState.ATTACK:
                  _attackTimer = 0;
                  _hitBox.SetActive(true);
                  _animator.SetBool("IsAttacking", true);
                  break;
              case EnemyState.DEAD:
                  _animator.SetBool("isDead", true);
                _waitingTimeBeforeAttack = 10;
                _speed = 0;
                _hitBox.SetActive(false);
                //faire apparaître les items à sa mort
                  break;
              default:
                  break;
          }
    }

    private void OnStateUpadate()
    {
          switch (_currentState)
          {
              case EnemyState.IDLE:
                  if(_playerDetected && !IsTargetNearLimit())
                  {
                      TransitionToState(EnemyState.WALK);
                  }
                  if(IsTargetNearLimit())
                  {
                      _attackTimer += Time.deltaTime;
                      if(_attackTimer >= _waitingTimeBeforeAttack)
                      {
                          TransitionToState(EnemyState.ATTACK);
                      }
                  }
                if (GetComponent<Health>().health == 0)
                {
                    TransitionToState(EnemyState.DEAD);
                }
                break;
              case EnemyState.WALK:

                 // transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, Time.deltaTime) * _speed;
                  transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, (Time.deltaTime * _speed));

                  if(IsTargetNearLimit())
                  {
                      TransitionToState(EnemyState.IDLE);
                  }
                  if (!_playerDetected)
                  {
                      TransitionToState(EnemyState.IDLE);
                  }
                if (GetComponent<Health>().health == 0)
                {
                    TransitionToState(EnemyState.DEAD);
                }
                break;
              case EnemyState.ATTACK:
                  _attackTimer += Time.deltaTime;
                  if (_attackTimer >= _attackduration)
                  {
                      TransitionToState(EnemyState.IDLE);
                  }
                if (GetComponent<Health>().health == 0)
                {
                    TransitionToState(EnemyState.DEAD);
                }
                    break;
              case EnemyState.DEAD:

                _animator.SetBool("isDead", true);
                //GetComponent<HitBox>()._damage = 0;
                _speed = 0;
                _hitBox.SetActive(false);
                //faire apparaître les items à sa mort

                break;
            default:
                  break;
          }
    }

    private void OnStateExit()
    {
          switch (_currentState)
          {
              case EnemyState.IDLE:
                  break;
              case EnemyState.WALK:
                  _animator.SetBool("IsWalking", false);
                  break;
              case EnemyState.ATTACK:
                  _hitBox.SetActive(false);
                  _animator.SetBool("IsAttacking", false);
                  break;
              case EnemyState.DEAD:
                _animator.SetBool("isDead", true);
                _waitingTimeBeforeAttack = 10;
                _speed = 0;
                _hitBox.SetActive(false);
                //faire apparaître les items à sa mort

                break;
            default:
                  break;
          }
    }

    private void TransitionToState(EnemyState nestState)
    {
        OnStateExit();
        _currentState = nestState;
        OnStateEnter();
    }

    public void PlayerDetected()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        Debug.Log("J'ai detecté le Player");
        _playerDetected = true;
    }

    public void PlayerEscaped()
    {
        _playerDetected = false;
    }

    private bool IsTargetNearLimit()
    {
        return Vector2.Distance(transform.position, _moveTarget.position) < _limitNearTarget;
    }

    void Flip()
    {
        if (transform.position.x < _moveTarget.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x > _moveTarget.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    #endregion

    #region Private & Protected

    private EnemyState _currentState;

    private bool _playerDetected = false;

    private float _attackTimer;

    private Transform _moveTarget;

    private GameObject[] _tapes;

    private GameObject[] _records;

    #endregion
}
