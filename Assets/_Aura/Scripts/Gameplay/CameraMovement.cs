using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3? basePointerPosition = null;
    public float cameraMovementSpeed = 0.05f;
    private int cameraXMin, cameraXMax, cameraZMin, cameraZMax;//will be set from GameManager

   
    public void MoveCamera(Vector3 pointerPosition)
    {
        Debug.Log("In camera movement");
        if (basePointerPosition.HasValue == false)
        {
            basePointerPosition = pointerPosition;
        }
        Vector3 newPosition = pointerPosition - basePointerPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);
        transform.Translate(newPosition * cameraMovementSpeed);
        LimitCameraPositionInsideBounds();
    }

    public void StopCameraMovement()
    {
        basePointerPosition = null;
    }

    public void SetCameraLimits(int minX, int maxX, int minZ,int maxZ)
    {
        cameraXMin = minX;
        cameraXMax = maxX;
        cameraZMin = minZ;
        cameraZMax = maxZ;
    }
    private void LimitCameraPositionInsideBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraXMin, cameraXMax), 0,
                    Mathf.Clamp(transform.position.z, cameraZMin, cameraZMax));
    }
}
