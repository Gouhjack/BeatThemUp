using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaHandler : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GameObject _specialAttack;

    [Header("Mana UI")]
    [SerializeField] 
    private Image _manaBar;
    [SerializeField]
    private GameObject _manaText;

    [Header("Mana Parameter")]
    [SerializeField] 
    private float _manaAmount;
    [SerializeField]
    private float _manaRegenAmount;
    [SerializeField]
    private float _manaMax = 100f;


    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {

    }

    void Start()
    {
        Mana();
    }

    void Update()
    {
        _manaAmount += _manaRegenAmount * Time.deltaTime;
        _manaAmount = Mathf.Clamp(_manaAmount, 0f, _manaMax);
        _manaBar.fillAmount = GetManaNormalized();
        if(_manaAmount == _manaMax)
        {
            _manaText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                _specialAttack.SetActive(true);
                SpendMana(_manaMax);
                _animator.SetBool("isSuperAttacking", true);
            }
        }
        
        else
        {
            _animator.SetBool("isSuperAttacking", false);
            _manaText.SetActive(false);
            _specialAttack.SetActive(false);
        }
    }
    #endregion

    #region Methods

    private void Mana()
    {
        _manaAmount = 0;
        _manaRegenAmount = 50f;
    }

    public void SpendMana(float amount)
    {
        if (_manaAmount >= amount)
        {
            _manaAmount -= amount;
        }
    }

    private float GetManaNormalized()
    {
        return _manaAmount / _manaMax;
    }
    #endregion

    #region Private & Protected

    #endregion
}
