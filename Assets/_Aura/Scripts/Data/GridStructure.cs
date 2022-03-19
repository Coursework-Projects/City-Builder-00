using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure
{
    private readonly int CELLSIZE = 3;

    //multidimensional data structure to hold the concept of a grid made up of cells
    Cell[,] grid;

    //values to determine the size in cell rows and cell columns of the grid
    //determined at construction
    int gridLength, gridWidth;
    public GridStructure(int sizeOfCell, int _gridLength, int _gridWidth)
    {
        this.CELLSIZE = sizeOfCell;
        this.gridLength = _gridLength;
        this.gridWidth = _gridWidth;

        grid = new Cell[gridLength, gridWidth];

        //build up the grid
        for(int row = 0;row < grid.GetLength(0); row++)
        {
            for(int col = 0;col < grid.GetLength(1); col++)
            {
                grid[row,col] = new Cell();
            }
        }
    }
    public Vector3 CalculateGridPosition(Vector3 mouseHitPos)
    {
        var xPos = (float)Mathf.FloorToInt(mouseHitPos.x / CELLSIZE);
        var zPos = (float)Mathf.FloorToInt(mouseHitPos.z / CELLSIZE);

        return new Vector3(xPos * CELLSIZE, 0f, zPos * CELLSIZE);

    }

    /// <summary>
    /// Given a position on the grid, method returns the
    /// index of the corresponding cell in the grid multidimentional
    /// array structure.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private Vector2Int CalculateGridPositionToCellIndex(Vector3 position)
    {
        return new Vector2Int((int)position.x / CELLSIZE, (int)position.z / CELLSIZE);
    }

    public bool IsCellTaken(Vector3 gridPos)
    {
        Vector2Int cellIndex = CalculateGridPositionToCellIndex(gridPos);
        if(CheckIndexValidity(cellIndex))
            return grid[cellIndex.x, cellIndex.y].CellIsTaken;
        throw new IndexOutOfRangeException("No Cell available at the index: " + cellIndex);
    }

    public void PlaceStructureOnGrid(GameObject structure,Vector3 gridPos)
    {
        //only do so if the cell is not taken
        Vector2Int cellIndex = CalculateGridPositionToCellIndex(gridPos);
        if(CheckIndexValidity(cellIndex))
            grid[cellIndex.x,cellIndex.y].SetCellStructureModel(structure);
    }

    private bool CheckIndexValidity(Vector2Int cellIndex)
    {
        if (cellIndex.x >= 0 && cellIndex.x < grid.GetLength(1) && cellIndex.y >= 0 && cellIndex.y < grid.GetLength(0))
            return true;
        return false;
    }
}
