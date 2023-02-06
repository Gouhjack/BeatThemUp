using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;

    #endregion

    #region Unity LifeCycle
    private void Awake()
    {
        _graphics = transform.Find("Graphics");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    Transform _graphics;
    float _jumpTimer;

    #endregion

    #region Private & Protected

    #endregion
}
