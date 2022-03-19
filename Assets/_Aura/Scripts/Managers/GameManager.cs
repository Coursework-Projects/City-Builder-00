using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager inputManager;
    public PlacementManager placementManager;

    [SerializeField] private int cellSize = 3;
    [SerializeField] private int gridLength;
    [SerializeField] private int gridWidth;
    GridStructure gridStructure;

    private void Start()
    {
        gridStructure = new GridStructure(cellSize, gridLength, gridWidth);

        //subscribe to inputManager event to listen out for mouse click events
        inputManager.SubscribeToOnMouseClick(HandleMouseInput);
    }

    void HandleMouseInput(Vector3 mouseClickPosition)
    {
        var gridPos = gridStructure.CalculateGridPosition(mouseClickPosition);
        if (gridStructure.IsCellTaken(gridPos) == false)
        {
            placementManager.CreateBuildingOnGrid(gridPos,gridStructure);
        }
    }

    private void OnDisable()
    {
        inputManager.UnSubscribeToOnMouseClick(HandleMouseInput);
    }
}
