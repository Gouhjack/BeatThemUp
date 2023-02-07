using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new IntVariable", menuName = "Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
    #region Expose

    public int m_value;

    #endregion

}
