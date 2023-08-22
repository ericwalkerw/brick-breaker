using System.Collections.Generic;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    public TextAsset levelAsset;
    public Transform[] gridBlock;
    public Transform BLockHolder;
    public GameObject blackBlock, greenBlock, yellowBlock;
    public int numRows = 0;
    public int numCols = 0;

    private void Start()
    {
        gridBlock = GetComponentsInChildren<Transform>();
        gridBlock = new List<Transform>(gridBlock).GetRange(1, gridBlock.Length - 1).ToArray();
        levelAsset = GameManeger.instance.levelAsset;
        LoadDataFromCSV();
    }
    private void LoadDataFromCSV()
    {
        if (levelAsset != null)
        {
            string[] lines = levelAsset.text.Split('\n');

            numRows = lines.Length - 1;
            numCols = lines[1].Split(',').Length;

            int[] flatMatrix = new int[numRows * numCols];

            for (int i = 2; i < numRows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < numCols; j++)
                {
                    int value;
                    if (int.TryParse(values[j], out value))
                    {
                        flatMatrix[(i - 2) * numCols + j] = value;
                        InstantiateByValue(value, gridBlock[(i - 2) * numCols + j]);
                    }
                }
            }
        }
    }

    public void InstantiateByValue(int value, Transform spawnTransform)
    {
        Vector3 spawnPosition = spawnTransform.position;

        switch (value)
        {
            case -1: Instantiate(blackBlock, spawnPosition, Quaternion.identity, BLockHolder); break;
            case 1: Instantiate(greenBlock, spawnPosition, Quaternion.identity, BLockHolder); break;
            case 2: Instantiate(yellowBlock, spawnPosition, Quaternion.identity, BLockHolder); break;
        }
    }
}
