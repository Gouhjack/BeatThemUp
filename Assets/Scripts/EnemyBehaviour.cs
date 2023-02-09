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
    
    //[Header("Life enemy")]
    //[SerializeField]
    //private int _healthpoint = 50;
    
    [Header("Item after death")]
    [SerializeField]
    private GameObject _tapePrefab;
    [SerializeField]
    private GameObject _recordPrefab;
    [SerializeField]
    private int _nbTapeItem; //Idéalement des IntVariable
    [SerializeField]
    private int _nbRecordItem; //Idémalement des IntVariable

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _tapes = new GameObject[_nbTapeItem];
        _records = new GameObject[_nbRecordItem];
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
        if (_moveTarget.position.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_moveTarget.position.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
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
                  _animator.SetBool("IsDead", true);
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
                  break;
              case EnemyState.ATTACK:
                  _attackTimer += Time.deltaTime;
                  if (_attackTimer >= _attackduration)
                  {
                      TransitionToState(EnemyState.IDLE);
                  }
                  break;
              case EnemyState.DEAD:
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

  //  private void SpawnItemAfterDeath()
  //  {
  //        for (int i = 0; i < _nbTapeItem; i++)
  //        {
  //          _tapes[i] = Instantiate(_tapePrefab, transform);
  //        }
  //        for (int i = 0; i < _nbRecordItem; i++)
  //        {
  //          _records[i] = Instantiate(_recordPrefab, transform);
  //        }
  //  }
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
