using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private int _health = 100;

    [SerializeField] 
    private int _healthMax = 100;

    [SerializeField]
    private RawImage _healthbar;

    [SerializeField]
    private RawImage _healthBarGrey;

    [SerializeField]
    private GameObject _gameOverScreen;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        _originHealth = _health;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Attack")) 
        {

            float coef = _health / _originHealth;
            _healthbar.rectTransform.sizeDelta = new Vector2(_healthBarGrey.rectTransform.sizeDelta.x * coef, _healthBarGrey.rectTransform.sizeDelta.y);
        }
    }
    #endregion

    #region Methods

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        Debug.Log(_healthMax);
        this._health -= amount;

        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _gameOverScreen.SetActive(true);
    }
    #endregion

    #region Private & Protected

    private int _originHealth;
    #endregion
}
