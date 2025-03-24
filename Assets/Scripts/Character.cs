using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int level;
    public int gold;
    public int attack;
    public int defense;
    public int health;
    public int critrate;

    public Character(string name, int initialLevel)
    {
        characterName = name;
        level = initialLevel;
    }

    
    public void SetCharacterName(string newName)
    {
        characterName = newName;
    }

  
    public void LevelUp()
    {
        level++;
    }

    public void AddGold(int g)
    {
        gold += g;
    }

}
