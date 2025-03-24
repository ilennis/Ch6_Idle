using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("Character Main")]
    public Text nameText;
    public Text levelText;
    public Text goldText;    

    public void UpdateCharacterUI(Character character)
    {
        if (nameText != null)
        {
            nameText.text = "Name: " + character.characterName;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + character.level.ToString();
        }
        if (goldText!= null)
        {
            levelText.text = character.gold.ToString();
        }

    }
}
