using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Expose

    [SerializeField]
    [Tooltip("Health = nombre de vie actuel")]
    private float _health = 100;

    [SerializeField] 
    private int _healthMax = 100;

    [SerializeField]
    private Image _healthbar;

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private int _nbLives;

    [SerializeField]
    private TextMeshProUGUI _liveCountText;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        _originHealth = _health;
    }

    void Update()
    {
        _liveCountText.text = _nbLives.ToString();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Attack")) 
    //    {

    //        float coef = _health / _originHealth;
    //        _healthbar.rectTransform.sizeDelta = new Vector2(_healthBarGrey.rectTransform.sizeDelta.x * coef, _healthBarGrey.rectTransform.sizeDelta.y);
    //    }
    //}
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
        _healthbar.fillAmount = _health / _healthMax;

        if(_health <= 0)
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        _nbLives--;
        _health = _healthMax;
        if (_nbLives == 0)
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

    private float _originHealth;
    #endregion
}
