using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManeger : MonoBehaviour
{
    #region SingleTon
    public static PotionManeger Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public List<GameObject> listPotion;
    public int DropPercent;
    public void PotionSpawn(Transform block)
    {
        int randPercent = Random.Range(1, 101);
        if (randPercent <= DropPercent)
        {
            int randomIndex = Random.Range(0, listPotion.Count);
            GameObject x = Instantiate(listPotion[randomIndex], block.position, Quaternion.identity);
            Destroy(x, 3f);
        }
    }
}
