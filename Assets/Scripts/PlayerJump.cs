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
        
        if (_jumpTimer < 1)
        {
            _jumpTimer += Time.deltaTime;

            float y = _jumpCurve.Evaluate(_jumpTimer);

            _graphics.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

            Debug.Log(y);
        }

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
