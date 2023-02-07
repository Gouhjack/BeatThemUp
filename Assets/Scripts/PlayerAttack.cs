using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Exposed



    #endregion

    #region Unity LifeCycle
    void Start()
    {
        
        _attackArea = transform.GetChild(0).gameObject;

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            Attack();
        }

        if (_attacking) 
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking= false;
                _attackArea.SetActive(_attacking);
            }

        }
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    private void Attack()
    {

        _attacking = true;
        _attackArea.SetActive(_attacking);

    }

    #endregion

    #region Private & Protected

    private GameObject _attackArea = default;

    private bool _attacking = false;

    private float _timeToAttack = 0.25f;
    private float _timer = 0f;

    #endregion
}
