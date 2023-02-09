using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private AudioSource _audio;

    #endregion

    #region Unity Lyfecycle
   
    #endregion

    #region Methods

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseAudio()
    {
        _audio.Pause();
    }

    public void PlayAudio()
    {
        _audio.Play();
    }

    #endregion

    #region Private & Protected

    #endregion
}
