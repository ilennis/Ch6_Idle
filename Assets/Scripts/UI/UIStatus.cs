using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [Header("Character Status")]
    [SerializeField] public Text _attackText;
    [SerializeField] public Text _defenseText;
    [SerializeField] public Text _healthText;
    [SerializeField] public Text _critText;
    public void UpdateStatusUI(Character character)
    {
       
        if (_attackText != null)
        {
            _attackText.text = "Name: " + character.characterName;
        }
        if (_defenseText != null)
        {
            _defenseText.text = "Level: " + character.level.ToString();
        }
        if (_healthText != null)
        {
            _healthText.text = "Name: " + character.characterName;
        }
        if (_critText != null)
        {
            _critText.text = "Level: " + character.level.ToString();
        }
    }
}
