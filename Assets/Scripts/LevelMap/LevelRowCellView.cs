using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelRowCellView : MonoBehaviour
{
    public GameObject container;
    public GameObject lockSprite;
    public TMP_Text text;
    public GameObject[] starSprite;
    public void SetData(LevelData data)
    {
        container.SetActive(data != null);

        if (data != null)
        {
            text.text = data.levelName;
            if (data.isUnLock)
            {
                lockSprite.SetActive(false);
                for (int i = 0; i < data.star; i++)
                {
                    starSprite[i].SetActive(true);
                }
            }
        }
    }
}
