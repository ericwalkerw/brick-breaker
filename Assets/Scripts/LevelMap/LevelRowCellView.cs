using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelRowCellView : MonoBehaviour
{
    public GameObject container;
    public GameObject lockSprite;
    public GameObject[] star;

    public TMP_Text text;

    private Data _data;
    public void SetData(DataLevelConfig data)
    {      
        container.SetActive(data != null);
        if (data != null)
        {
            text.text = data.levelName;
        }
    }

    public void SetUserData(Data data)
    {
        _data = data;
        if (data.isUnLock)
        {
            lockSprite.SetActive(false);
            for (int i = 0; i < data.star; i++)
            {
                star[i].SetActive(true);
            }
        }
        else
        {
            lockSprite.SetActive(true);
            foreach (var item in star)
            {
                item.SetActive(false);
            }
        }
    }
    public void ChooseLevel()
    {
        if (_data.isUnLock)
        {
            SceneManager.LoadScene("GamePlay");
            GameManeger.instance.GetAsset(_data.id);
        }
    }
}

