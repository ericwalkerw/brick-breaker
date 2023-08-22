using UnityEngine;
using System.Collections;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;

namespace Assets.Scripts.LevelMap
{
    public class LevelMapManeger : MonoBehaviour, IEnhancedScrollerDelegate
    {
        [HideInInspector] public ListData _data;
        [HideInInspector] public UserData _userData;
        public EnhancedScroller scroller;
        public EnhancedScrollerCellView cellViewPrefab;

        public int numberOfCellsPerRow = 3;
        void Start()
        {
            _data = GameManeger.instance.config;
            _userData = GameManeger.instance.userData;
            scroller.Delegate = this;
            LevelUI.Instance.StarUpdate(SumStar());
            UnLockNextLevel();
        }
        #region EnhancedScroller Handlers
        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return Mathf.CeilToInt((_data.dataConfig.Count) / (float)numberOfCellsPerRow);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 160;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            LevelCellView cellView = scroller.GetCellView(cellViewPrefab) as LevelCellView;
            cellView.name = "Cell " + (dataIndex * numberOfCellsPerRow).ToString() + " to " + (dataIndex * numberOfCellsPerRow + numberOfCellsPerRow - 1).ToString();
            cellView.SetData(ref _data.dataConfig, dataIndex * numberOfCellsPerRow, dataIndex);
            cellView.SetUserData(ref _userData.data, dataIndex * numberOfCellsPerRow, dataIndex);
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
            foreach (var item in _userData.data)
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
            for (int i = 0; i < _userData.data.Count; i++)
            {
                if (_userData.data[i].UnLock())
                {
                    _userData.data[i].isUnLock = true;
                    _userData.data[i + 1].isUnLock = true;
                }
            }
        }
    }
}