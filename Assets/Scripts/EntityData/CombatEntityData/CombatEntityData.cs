using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCombatEntityData", menuName = "Data/Combat Entity")]
public class CombatEntityData : ScriptableObject
{
    [Header("Base Stats and Growth Rates")]
    public float Hp;
    public float HpGrowthRate;
    [Space(10)] 
    public float Mp;
    public float MpGrowthRate;
    [Space(10)]
    public float Stm;
    public float StmGrowthRate;
    [Space(10)]
    public float Str;
    public float StrGrowthRate;
    [Space(10)]
    public float Mag;
    public float MagGrowthRate;
    [Space(10)]
    public float Def;
    public float DefGrowthRate;
    [Space(10)]
    public float Res;
    public float ResGrowthRate;
    [Space(10)]
    public float Spd;
    public float SpdGrowthRate;
}
