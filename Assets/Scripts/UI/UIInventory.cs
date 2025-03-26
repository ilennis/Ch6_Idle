using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public UIManager manager;
    public Character currentCharacter;
    public GameObject slotPrefab;   
    public Transform inventoryContent;  // Transform�� �θ� ����
    private GameObject uiSlot;

    public List<GameObject> slots = new List<GameObject>(); // UISlot ������ �߰�
    public List<ItemData> items = new List<ItemData>();
    

    public void Start()
    {
        currentCharacter = GameManager._instance.player;
        InitInventoryUI(currentCharacter);
    }
    public void InitInventoryUI(Character character)
    {
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();


        foreach (ItemData item in character.inventory)
        {
            GameObject newSlot = Instantiate(slotPrefab, inventoryContent);
            UISlot uiSlot = newSlot.GetComponent<UISlot>();
            uiSlot.SetItem(item, this); // UI Slot�� ������ �߰�
            Button slotButton = newSlot.GetComponent<Button>();
            slotButton.onClick.AddListener(() => ToggleEquip(item));
            slots.Add(newSlot);
        }
    }
    public void ToggleEquip(ItemData item)
    {
        
        if (item.isEquipped)
            currentCharacter.UnEquip(item);
        else
            currentCharacter.Equip(item);

        manager.UpdateCharacterUI(currentCharacter); // UI �ʱ�ȭ
    }

}
