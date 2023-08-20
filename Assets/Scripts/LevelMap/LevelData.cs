using UnityEngine;

[CreateAssetMenu()]
public class LevelData:ScriptableObject
{
    public string levelName;
    public int star;
    public bool isUnLock;

    public bool UnlockLevel() => star >= 2;

#if UNITY_EDITOR
    private void OnValidate()
    {
        levelName = this.name;
    }  
#endif
}
