using System;
using UnityEngine;

public interface IInputManager
{
    void SubscribeToOnMouseClick(Action<Vector3> listener);
    void SubscribeToOnRightMouseDown(Action<Vector3> listener);
    void SubscribeToOnRightMouseUp(Action listener);
    void UnSubscribeToOnMouseClick(Action<Vector3> listener);
    void UnSubscribeToOnRightMouseDown(Action<Vector3> listener);
    void UnSubscribeToOnRightMouseUp(Action listener);
}