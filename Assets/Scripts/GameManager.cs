using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private IntVariable _recordScore;
    [SerializeField]
    private IntVariable _tapeScore;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _recordScore.m_value = 0;
        _tapeScore.m_value = 0;
    }

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
