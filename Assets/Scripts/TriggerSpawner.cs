using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab; // le pr�fabriqu� d'ennemi � instancier
    [SerializeField] public Transform spawnPoint; // l'emplacement o� instancier l'ennemi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // v�rifie si le joueur est entr� dans la zone
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // instancie l'ennemi au bon endroit
        }
    }
}
