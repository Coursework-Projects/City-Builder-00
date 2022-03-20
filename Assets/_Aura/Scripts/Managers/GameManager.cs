using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IInputManager inputManager;
    public PlacementManager placementManager;
    public UIController controller;
    public CameraMovement cameraMovement;

    [SerializeField] private int cellSize = 3;
    [SerializeField] private int gridLength;
    [SerializeField] private int gridWidth;

    private bool flagIsBuildActionActive;

    GridStructure gridStructure;

    private void Start()
    {
        cameraMovement.SetCameraLimits(0,gridWidth,0,gridLength);
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        controller.SubscribeToOnBuildArea(StartBuildMode);
        controller.SubscribeToOnCancelBuildArea(ActivateCancelMode);
        gridStructure = new GridStructure(cellSize, gridLength, gridWidth);

        //subscribe to inputManager event to listen out for mouse click events
        inputManager.SubscribeToOnMouseClick(HandleMouseInput);
        inputManager.SubscribeToOnRightMouseDown(HandleOnRightMouseDownPanning);
        inputManager.SubscribeToOnRightMouseUp(HandleOnRightMouseUpStopPanning);
    }

    void HandleMouseInput(Vector3 mouseClickPosition)
    {
        var gridPos = gridStructure.CalculateGridPosition(mouseClickPosition);
        if (flagIsBuildActionActive && gridStructure.IsCellTaken(gridPos) == false)
        {
            placementManager.CreateBuildingOnGrid(gridPos, gridStructure);
        }
    }

    void HandleOnRightMouseDownPanning(Vector3 panToPosition)
    {
        if (flagIsBuildActionActive == false)//only pan around in selection mode
        {
            cameraMovement.MoveCamera(panToPosition);
        }
    }

    void HandleOnRightMouseUpStopPanning()
    {
        cameraMovement.StopCameraMovement();
    }

    void StartBuildMode()
    {
        flagIsBuildActionActive = true;
    }

    void ActivateCancelMode()
    {
        flagIsBuildActionActive = false;
    }

    private void OnDisable()
    {
        inputManager.UnSubscribeToOnMouseClick(HandleMouseInput);
        inputManager.UnSubscribeToOnRightMouseDown(HandleOnRightMouseDownPanning);
        inputManager.UnSubscribeToOnRightMouseUp(HandleOnRightMouseUpStopPanning);
    }
}
