using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    #region SingleTon
    public static LevelUI Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public TMP_Text starValue;
    public TMP_Text levelText;

    public void StarUpdate(int value)
    {
        starValue.text = value.ToString();
    }

    public void LevelUpdate(int value)
    {
        levelText.text = $"Your Level : {value}";
    }

}
