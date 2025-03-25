using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Create New Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public int level;
    public int gold;
    public int attack;
    public int defense;
    public int health;
    public int critrate;
    public List<ItemData> inventory = new List<ItemData>(); // �κ��丮 ����Ʈ �߰�

   
    
    public void SetCharacterName(string newName)
    {
        characterName = newName;
    }

  
    public void LevelUp()
    {
        level++;
        attack = 5 + (level * 5);
        defense = 5 + (level * 5);
        health = 90 + (level * 10);
        critrate = 25;
    }

    public void AddGold(int g)
    {
        gold += g;
    }

    public void AddItem(ItemData item)
    {
        if (!inventory.Contains(item))
        {
            inventory.Add(item);
            Debug.Log($"{characterName} �� {item.itemName} �� �κ��丮�� �߰�.");
        }
    }

    public void Equip(ItemData item)
    {
        if (inventory.Contains(item) && !item.isEquipped)
        {
            attack += item.attack;
            defense += item.defense;
            health += item.health;
            critrate += item.critrate;
            item.isEquipped = true;
            Debug.Log($"{characterName} �� {item.itemName}�� ����.");
        }
    }
    public void UnEquip(ItemData item)
    {
        if (inventory.Contains(item) && item.isEquipped)
        {
            attack -= item.attack;
            defense -= item.defense;
            health -= item.health;
            critrate -= item.critrate;
            item.isEquipped = false;
            Debug.Log($"{characterName} �� {item.itemName} ��������.");
        }
    }

}
