using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    
    public Character currentCharacter;
    public GameObject slotPrefab;   
    public Transform inventoryContent;  // Transform�� �θ� ����
    private GameObject uiSlot;

    public List<GameObject> slots = new List<GameObject>(); // UISlot ������ �߰�
    public List<ItemData> items = new List<ItemData>();
    

    public void Start()
    {
        InitInventoryUI();
    }
    public void InitInventoryUI()
    {
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();


        for (int i = 0; i < currentCharacter.inventory.Count; i++) // for each �� �ߴµ� �ε��� �ʿ��ؼ� ����
        {
            ItemData item = currentCharacter.inventory[i];
            GameObject newSlot = Instantiate(slotPrefab, inventoryContent);
            UISlot uiSlot = newSlot.GetComponent<UISlot>();

            uiSlot.SetItem(item, this); // Pass UI Manager reference for button clicks

            slots.Add(newSlot);
        }
    }
    public void ToggleEquip(ItemData item)
    {
        
        if (item.isEquipped)
            currentCharacter.UnEquip(item);
        else
            currentCharacter.Equip(item);

        InitInventoryUI(); // UI �ʱ�ȭ
    }

}
