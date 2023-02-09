using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    #region Expose

    #endregion

    #region Unity Lyfecycle
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth health = collider.GetComponent<PlayerHealth>();
            health.Damage(_damage);
            Debug.Log("dégat de l'ennemi : " + _damage);
        }
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private int _damage = 5;
    #endregion
}
