using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 여기 위에는 상태에 따라 ON/OFF를 위해 추가
    public GameObject mainUI;
    public GameObject statusUI;
    public GameObject inventoryUI;

    // UI 내용 직접 관리
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
  
    public void UpdateCharacterUI(Character character)
    {
        mainMenu.UpdateCharacterUI(character);
        statusMenu.UpdateStatusUI(character);
        inventoryMenu.InitInventoryUI(character);
    }
}

