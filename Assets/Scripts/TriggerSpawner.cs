using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab; // le préfabriqué d'ennemi à instancier
    [SerializeField] public Transform spawnPoint; // l'emplacement où instancier l'ennemi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // vérifie si le joueur est entré dans la zone
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // instancie l'ennemi au bon endroit
        }
    }
}
