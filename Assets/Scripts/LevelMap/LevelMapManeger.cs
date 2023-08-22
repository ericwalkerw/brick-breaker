using UnityEngine;
using System.Collections;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;

namespace Assets.Scripts.LevelMap
{
    public class LevelMapManeger : MonoBehaviour, IEnhancedScrollerDelegate
    {
        public ListData _data;
        public EnhancedScroller scroller;
        public EnhancedScrollerCellView cellViewPrefab;

        public int numberOfCellsPerRow = 3;
        void Start()
        {
            scroller.Delegate = this;
            LevelUI.Instance.StarUpdate(SumStar());
            UnLockNextLevel();
        }
        #region EnhancedScroller Handlers
        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return Mathf.CeilToInt((_data.data.Count) / (float)numberOfCellsPerRow);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 160;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            LevelCellView cellView = scroller.GetCellView(cellViewPrefab) as LevelCellView;
            cellView.name = "Cell " + (dataIndex * numberOfCellsPerRow).ToString() + " to " + (dataIndex * numberOfCellsPerRow + numberOfCellsPerRow - 1).ToString();
            cellView.SetData(ref _data.data, dataIndex * numberOfCellsPerRow, dataIndex);
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
            foreach (var item in _data.data)
            {
                if (item.star != 0)
                {
                    sum += item.star;
                }
            }
            return sum;
        }

        public void UnLockNextLevel()
        {
            for (int i = 0; i < _data.data.Count; i++)
            {
                if (_data.data[i].UnLock())
                {
                    _data.data[i+1].isUnLock = true;
                }
            }
        }
    }
}