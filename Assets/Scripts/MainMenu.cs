using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Expose

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        
    }

    void Update()
    {
        StartGame();
    }
    #endregion

    #region Methods

    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Je vais dans le jeu");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    #endregion

    #region Private & Protected

    #endregion
}
