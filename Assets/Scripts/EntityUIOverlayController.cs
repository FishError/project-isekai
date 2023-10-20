using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityUIOverlayController : MonoBehaviour
{
    public CombatEntity combatEntity;
    public TextMeshProUGUI entityName;
    public GameObject HpBar;
    public Slider HpSlider;
    public TextMeshProUGUI HpNumbers;

    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetValues()
    {
        HpNumbers.text = combatEntity.Hp + "/" + combatEntity.CurrentHp;
    }

    public void SetHpBar()
    {
        HpSlider.value = combatEntity.CurrentHp / combatEntity.Hp;
        HpNumbers.text = combatEntity.Hp + "/" + combatEntity.CurrentHp;
    }
}
