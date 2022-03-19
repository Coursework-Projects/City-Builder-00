using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputLayerMask;

    public Action<Vector3> OnMouseClickEvent;
    

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




}
