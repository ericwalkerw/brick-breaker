using UnityEngine;
using EnhancedUI.EnhancedScroller;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class LevelCellView : EnhancedScrollerCellView
{
    public LevelRowCellView[] rowCellViews;
    public GridLayoutGroup layout;
    int count = 0;
    public void SetData(ref List<Data> data, int startingIndex, int row)
    {
        if (row %2 != 0)
        {
            layout.startCorner = GridLayoutGroup.Corner.LowerRight;
        }
        for (var i = 0; i < rowCellViews.Length; i++)
        {
            rowCellViews[i].SetData(startingIndex + i < data.Count ? data[startingIndex + i] : null);
        }
    }
}
