using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private IntVariable _item;
    [SerializeField]
    private int _score;
    [SerializeField]
    private AudioSource _itemSound;

    #endregion

    #region Unity Lyfecycle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _item.m_value += _score;
            _itemSound.Play();
            Destroy(gameObject);
        }
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    #endregion
}
