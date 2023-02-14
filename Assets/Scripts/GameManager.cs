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
    [SerializeField]
    private IntVariable _enemyScore;
    [SerializeField]
    private GameObject _victoryUi;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _recordScore.m_value = 0;
        _tapeScore.m_value = 0;
        _enemyScore.m_value = 0;
    }

    private void Update()
    {
        Victory();
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

    private void Victory()
    {
        _enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enemiesArray.Length == 0)
        {
            _victoryUi.SetActive(true);
        }
    }
    #endregion

    #region Private & Protected

    private GameObject[] _enemiesArray;

    #endregion
}
