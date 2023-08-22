using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataLevelConfig
{
    public int id;
    public string levelName;
    public TextAsset levelAsset;
}

[CreateAssetMenu()]
public class ListData : ScriptableObject
{
    public List<DataLevelConfig> dataConfig = new List<DataLevelConfig>();

#if UNITY_EDITOR
    private void OnValidate()
    {
        for (int i = 1; i < dataConfig.Count; i++)
        {
            dataConfig[0].levelName = "Tutorial";
            dataConfig[i].id = i;
            dataConfig[i].levelName = i.ToString();
        }
    }
#endif
}
