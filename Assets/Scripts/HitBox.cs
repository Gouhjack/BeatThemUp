using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    #region Expose

    [SerializeField] public int _damage = 5;

    #endregion

    #region Unity Lyfecycle
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth health = collider.GetComponent<PlayerHealth>();
            health.Damage(_damage);
            Debug.Log("d�gat de l'ennemi : " + _damage);
        }
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    
    #endregion
}
