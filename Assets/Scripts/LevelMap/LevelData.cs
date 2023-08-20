using UnityEngine;

[CreateAssetMenu()]
public class LevelData:ScriptableObject
{
    public string levelName;
#if UNITY_EDITOR
    private void OnValidate()
    {
        levelName = this.name;
    }
   
#endif
}
