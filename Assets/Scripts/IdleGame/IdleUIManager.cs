using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleUIManager : MonoBehaviour
{
    public Slider hpBar;
    public Slider expBar;
    public Text hpText;
    public Text expText;
    public Text goldText;
    public Button healButton;
    public Button attack;
    public Button levelup;


    private int gold = 100;
    private float hp = 100, maxHp = 100;
    private float exp = 0, maxExp = 100;

    void Start()
    {
        UpdateUI();

        healButton.onClick.AddListener(Heal);
        attack.onClick.AddListener(AttackBoost);
        levelup.onClick.AddListener(LevelUp);
        
    }
    public void UpdateUI()
    {
        hpBar.value = hp / maxHp;
        expBar.value = exp / maxExp;
        hpText.text = $"HP: {hp.ToString()} / {maxHp.ToString()}";
        expText.text = $"HP: {exp.ToString()} / {maxExp.ToString()}";
        goldText.text = "Gold: " + gold;
    }
    void Heal()
    {
        if (gold >= 10)
        {
            hp = Mathf.Min(maxHp, hp + 20);
            gold -= 10;
            UpdateUI();
        }
    }
    void AttackBoost()
    {
        if (gold >= 20)
        {
            // Implement Attack Boost logic here
            gold -= 20;
            UpdateUI();
        }
    }    
    void LevelUp()
    {
        if (gold >= 50)
        {
            maxHp += 10;
            gold -= 50;
            UpdateUI();
        }
    }
}
