using UnityEngine;
using System.Collections;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using System.Collections.Generic;

namespace Assets.Scripts.LevelMap
{
    public class LevelMapManeger : MonoBehaviour, IEnhancedScrollerDelegate
    {
        public List<LevelData> _data;
        public EnhancedScroller scroller;
        public EnhancedScrollerCellView cellViewPrefab;
        public int numberOfCellsPerRow = 3;
        private void OnEnable()
        {
            
        }
        void Start()
        {
            LevelUI.Instance.StarUpdate(SumStar());
            scroller.Delegate = this;
            UnlockNextLevel();
        }
        #region EnhancedScroller Handlers
        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return Mathf.CeilToInt(_data.Count / (float)numberOfCellsPerRow);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 160;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            LevelCellView cellView = scroller.GetCellView(cellViewPrefab) as LevelCellView;
            cellView.name = "Cell " + (dataIndex * numberOfCellsPerRow).ToString() + " to " + (dataIndex * numberOfCellsPerRow + numberOfCellsPerRow - 1).ToString();
            cellView.SetData(ref _data, dataIndex * numberOfCellsPerRow, dataIndex);
            return cellView;
        }

        #endregion

        private void Reverse()
        {
            scroller.ScrollRect.verticalNormalizedPosition = 1;
            //_data.Reverse();
        }

        public int SumStar()
        {
            int sum = 0;
            foreach (var item in _data)
            {
                sum += item.star;
            }
            return sum;
        }

        public void UnlockNextLevel()
        {
            for (int i = 0; i < _data.Count - 1; i++)
            {
                if (_data[i].UnlockLevel())
                {
                    _data[i + 1].isUnLock = true;
                    LevelUI.Instance.LevelUpdate(i+1);
                }
            }
        }
    }
}