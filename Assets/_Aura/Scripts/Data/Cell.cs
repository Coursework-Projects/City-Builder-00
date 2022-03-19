using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//data model to contain info about a single cell
public class Cell 
{
    //the structure spawned on the cell
    GameObject structureModel = null;

    bool cellIsTaken;

    public bool CellIsTaken { get => cellIsTaken;}

    public void SetCellStructureModel(GameObject newStructure)
    {
        this.structureModel = newStructure;
        this.cellIsTaken = true;
    }
}
