using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputLayerMask;
    public GameObject testBuildingPrefab;
    private const int CELLSIZE = 3;

    private void Update()
    {
        GetMouseInput();
    }

    void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mouseInputLayerMask))
            {
                var position = hitInfo.point - transform.position;
                CreateBuildingOnGrid(CalculateGridPosition(position));     
            }
        }

    }

    private void CreateBuildingOnGrid(Vector3 mouseHitPos)
    {
        Instantiate(testBuildingPrefab, mouseHitPos, Quaternion.identity);
    }

    Vector3 CalculateGridPosition(Vector3 mouseHitPos)
    {
        var xPos = (float)Mathf.FloorToInt(mouseHitPos.x/CELLSIZE);
        var zPos = (float)Mathf.FloorToInt(mouseHitPos.z/CELLSIZE);

        return new Vector3(xPos*CELLSIZE,0f, zPos * CELLSIZE);
    }
}
