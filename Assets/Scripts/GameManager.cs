using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public Character[] characters;
    public Character player;
    private int _currentCharacterIndex = 0;

    public static GameManager _instance { get; private set; }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        if (player != null)
        {
            SetData(player);
        }
        else if (characters.Length > 0)
        {
            SetData(characters[0]);  // Default to first character
        }
    }

    // Update is called once per frame
    public void SetData(Character character)
    {
        if (character != null)
        {
            player = character;  // 현재 플레이어 데이터 제작
            player.level = 1;
            uiManager.UpdateCharacterUI(player);  // Update UI
        }
    }

    public void SwitchCharacter(int index)
    {
        if (index >= 0 && index < characters.Length)
        {
            _currentCharacterIndex = index;
            SetData(characters[_currentCharacterIndex]); // Update player data
        }
    }

    public void LevelUpCharacter()
    {
        if (player != null)
        {
            player.level++;
            uiManager.UpdateCharacterUI(player);
        }
    }

    public void ChangeCharacterName(string newName)
    {
        if (player != null)
        {
            player.characterName = newName;
            uiManager.UpdateCharacterUI(player);
        }
    }
}
