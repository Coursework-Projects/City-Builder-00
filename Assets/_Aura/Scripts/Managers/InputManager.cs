using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager
{
    public LayerMask mouseInputLayerMask;

    public Action<Vector3> OnMouseClickEvent;

    //delegates to handle rightMouseButtonDown and Up inputs for camera panning
    public Action<Vector3> OnRightMouseDown;
    public Action OnRightMouseUp;


    private void Update()
    {
        GetLeftMousePositionInput();
        GetRightMousePanningInput();
    }

    private void GetRightMousePanningInput()
    {
        if (Input.GetMouseButton(1))
        {
            //handle right mouse down input
            OnRightMouseDown?.Invoke(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            OnRightMouseUp?.Invoke();
        }
    }

    void GetLeftMousePositionInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mouseInputLayerMask))
            {
                var position = hitInfo.point - transform.position;

                //publish event to listeners
                OnMouseClickEvent?.Invoke(position);

            }

        }

        

    }

    //Subscription method to allow other classes to register to the event
    public void SubscribeToOnMouseClick(Action<Vector3> listener)
    {
        OnMouseClickEvent += listener;
    }

    public void UnSubscribeToOnMouseClick(Action<Vector3> listener)
    {
        OnMouseClickEvent -= listener;
    }


    public void SubscribeToOnRightMouseDown(Action<Vector3> listener)
    {
        OnRightMouseDown += listener;
    }

    public void UnSubscribeToOnRightMouseDown(Action<Vector3> listener)
    {
        OnRightMouseDown -= listener;
    }


    public void SubscribeToOnRightMouseUp(Action listener)
    {
        OnRightMouseUp += listener;
    }

    public void UnSubscribeToOnRightMouseUp(Action listener)
    {
        OnRightMouseUp -= listener;
    }


}
