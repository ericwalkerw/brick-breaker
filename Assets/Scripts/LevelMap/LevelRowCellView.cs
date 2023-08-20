using UnityEngine;
using TMPro;

public class LevelRowCellView : MonoBehaviour
    {
        public GameObject container;
        public TMP_Text text;
        public void SetData(LevelData data)
        {
            container.SetActive(data != null);

            if (data != null)
            {
                text.text = data.levelName;
            }
        }
    }
