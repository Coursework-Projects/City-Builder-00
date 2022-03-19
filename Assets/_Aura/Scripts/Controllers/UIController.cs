using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button buildResidentialAreaBtn;
    public Button cancelBuildAreaBtn;
    public GameObject cancelBuildAreaPanel;

    Action OnCancelBuildArea;
    Action OnBuildArea;
    private void Start()
    {
        buildResidentialAreaBtn.onClick.AddListener(HandleBuildAreaAction);
        cancelBuildAreaBtn.onClick.AddListener(HandleCancelBuildAreaAction);

        cancelBuildAreaPanel.SetActive(false);
    }

    #region Event Subscription Unsubscription Methods
    public void SubscribeToOnBuildArea(Action listener)
    {
        OnBuildArea += listener;
    }
    public void UnsubscribeToOnBuildArea(Action listener)
    {
        OnBuildArea -= listener;
    }
    public void SubscribeToOnCancelBuildArea(Action listener)
    {
        OnCancelBuildArea += listener;
    }
    public void UnsubscribeToOnCancelBuildArea(Action listener)
    {
        OnCancelBuildArea -= listener;
    }
    #endregion

    #region Event Invocation Methods
    private void HandleBuildAreaAction()
    {
        OnBuildArea?.Invoke();
        cancelBuildAreaPanel.SetActive(true);

    }

    private void HandleCancelBuildAreaAction()
    {
        OnCancelBuildArea?.Invoke();
        cancelBuildAreaPanel.SetActive(false);

    }
    #endregion
}
