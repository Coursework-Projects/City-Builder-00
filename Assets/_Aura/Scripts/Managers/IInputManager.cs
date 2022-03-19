using System;
using UnityEngine;

public interface IInputManager
{
    void SubscribeToOnMouseClick(Action<Vector3> listener);
    void UnSubscribeToOnMouseClick(Action<Vector3> listener);
}