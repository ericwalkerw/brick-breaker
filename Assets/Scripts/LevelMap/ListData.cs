using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int id;
    public string levelName;
    public int star;
    public bool isUnLock;
    public TextAsset levelAsset;
    public bool UnLock() => star >= 2;
}
[CreateAssetMenu()]
public class ListData : ScriptableObject
{
    public List<Data> data = new List<Data>();

#if UNITY_EDITOR
    private void OnValidate()
    {
        for (int i = 1; i < data.Count; i++)
        {
            data[0].levelName = "Tutorial";
            data[i].id = i;
            data[i].levelName = i.ToString();
        }
    }

#endif
}
