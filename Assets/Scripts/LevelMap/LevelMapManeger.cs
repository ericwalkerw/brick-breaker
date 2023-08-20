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
        private List<LevelCellView> ListCell = new List<LevelCellView>();
        private void OnEnable()
        {
            
        }
        void Start()
        {
            Reverse();
            scroller.Delegate = this;
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
            ListCell.Add(cellView);
            return cellView;
        }

        #endregion

        private void Reverse()
        {
            scroller.ScrollRect.verticalNormalizedPosition = 1;
            //_data.Reverse();
        }
    }


}