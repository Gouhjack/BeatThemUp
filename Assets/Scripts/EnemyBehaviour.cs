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
    private float _limitNearTarget;
    [SerializeField]
    private float _waitingTimeBeforeAttack;
    [SerializeField]
    private float _attackduration;
    [SerializeField]
    private GameObject _hitBox;
    [SerializeField]
    private Transform _moveTarget;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        TransitionToState(EnemyState.IDLE);
        _moveTarget = GameObject.Find("Player").transform;
    }

    void Update()
    {
        OnStateUpadate();
    }
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
                    //J'execute ce code quand je suis en IDLe prêt du joueur
                    //Compteur de seconde
                    //TransitiontoState pour changer quand c'est bon
                    _attackTimer += Time.deltaTime;
                    if(_attackTimer >= _waitingTimeBeforeAttack)
                    {
                        TransitionToState(EnemyState.ATTACK);
                    }
                }
                break;
            case EnemyState.WALK:

                transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, Time.deltaTime);

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
  #endregion

  #region Private & Protected

  private EnemyState _currentState;

    private bool _playerDetected = false;

    private float _attackTimer;

    #endregion
}
