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
        
    }
    #endregion

    #region Methods

    public void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    #endregion

    #region Private & Protected

    #endregion
}
