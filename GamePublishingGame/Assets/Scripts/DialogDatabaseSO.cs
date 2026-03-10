using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogDatabaseSO", menuName = "Dialog System/DialogDatabaseSO")]
public class DialogDatabaseSO : ScriptableObject
{
    public List<DialogData> dialogData;
    public Dictionary<int, DialogLineSO> dialogDictionary = new Dictionary<int, DialogLineSO>();

    public void Initialize()
    {
        foreach (DialogData data in dialogData)
        {
            dialogDictionary.Add(data.id, data.config);
        }
    }
}

[Serializable]
public class DialogData
{
    public int id;
    public DialogLineSO config;
}
