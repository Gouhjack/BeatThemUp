using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private IntVariable _tapeScore;
    [SerializeField]
    private IntVariable _recordScore;
    [SerializeField]
    private IntVariable _enemyScore;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _textScore = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {

    }
    void Update()
    {
        _textScore.text = (_tapeScore.m_value + _recordScore.m_value + _enemyScore.m_value).ToString();
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private TextMeshProUGUI _textScore;

    #endregion
}
