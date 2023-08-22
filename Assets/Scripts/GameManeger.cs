using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    #region Singleton
    public static GameManeger instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance);
        }
    }
    #endregion

    public ListData listData;
    public int id;

    public TextAsset levelAsset;
    public void GetAsset(int id)
    {
        this.id = id;
        levelAsset = listData.data[id].levelAsset;
    }
}
