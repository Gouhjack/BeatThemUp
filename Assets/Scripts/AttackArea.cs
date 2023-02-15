using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private int _damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(_damage);
            Debug.Log(_damage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Fin de la collision");
    }
}
