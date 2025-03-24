using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject statusUI;
    public GameObject inventoryUI;


    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus statusMenu;
    [SerializeField] private UIInventory inventoryMenu;

    private enum UIState { Main, Status, Inventory }
    private UIState currentState;

    public static UIManager _instance { get; private set; }
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        ChangeState(UIState.Main);
    }

    public void OnMainButtonPressed()
    {
        ChangeState(UIState.Main);
    }

    public void OnStatusButtonPressed()
    {
        ChangeState(UIState.Status);
    }

    public void OnInventoryButtonPressed()
    {
        ChangeState(UIState.Inventory);
    }

    private void ChangeState(UIState newState)
    {
        currentState = newState;

        mainUI.SetActive(currentState == UIState.Main);
        statusUI.SetActive(currentState == UIState.Status);
        inventoryUI.SetActive(currentState == UIState.Inventory);
    }

    private void UpdateText()
    {
        
    }
}

