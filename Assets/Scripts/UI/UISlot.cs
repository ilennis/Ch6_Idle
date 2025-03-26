using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image itemIcon;
    public GameObject equipIcon;
    public ItemData itemData;
    private UIInventory inventory;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetItem(ItemData item, UIInventory inven)
    {
        itemData = item;
        inventory = inven;
        itemIcon.sprite = item.icon;
        equipIcon.SetActive(item.isEquipped);
        RefreshUI();
    }
    private void OnSlotClicked()
    {
        if (inventory != null && itemData != null)
        {
            inventory.ToggleEquip(itemData);
        }
    }
    public void RefreshUI()
    {
        itemIcon.sprite = itemData.icon;
        equipIcon.SetActive(itemData.isEquipped);
    }
}
