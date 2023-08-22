using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int id;
    public int star;
    public bool isUnLock;
    public bool UnLock() => star >= 2;
}

[CreateAssetMenu()]
public class UserData : ScriptableObject
{
    public List<Data> data = new List<Data>();

    private void OnValidate()
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i].id = i;
        }
    }
}
