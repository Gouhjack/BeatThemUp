using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPrefab : MonoBehaviour
{

       [SerializeField] public GameObject prefabToInstantiate;

        private void OnTriggerEnter2D(Collider2D col)
        {
            // Check if the col was with a specific tag or layer
            if (col.gameObject.CompareTag("Enemy"))
            {
            Debug.Log(col.gameObject.name + " touché");
                // Get the position and rotation of the col point
                Vector3 contactPoint = col.transform.position;
                Quaternion contactRotation = Quaternion.identity;

                // Instantiate the prefab at the point of impact with the appropriate rotation
                Instantiate(prefabToInstantiate, contactPoint, contactRotation);
            }
        }
}

