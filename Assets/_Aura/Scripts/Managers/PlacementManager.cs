using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject testBuildingPrefab;
    public Transform parent;
    public void CreateBuildingOnGrid(Vector3 mouseHitPos, GridStructure grid)
    {
        var spawnedStructure = Instantiate(testBuildingPrefab, parent.position + mouseHitPos, Quaternion.identity);
        grid.PlaceStructureOnGrid(spawnedStructure, mouseHitPos);
    }
}
