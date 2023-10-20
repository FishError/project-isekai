using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatEntity : PhysicsEntity
{
    public CombatEntityData data;

    public float lvl;

    #region Base Stats
    public float Hp { get; protected set; }
    public float Mp { get; protected set; }
    public float Stm { get; protected set; }
    public float Str { get; protected set; }
    public float Mag { get; protected set; }
    public float Def { get; protected set; }
    public float Res { get; protected set; }
    public float Spd { get; protected set; }
    #endregion

    #region Current Stats
    public float CurrentHp { get; protected set; }
    public float CurrentMp { get; protected set; }
    public float CurrentStm { get; protected set; }
    public float CurrentStr { get; protected set; }
    public float CurrentMag { get; protected set; }
    public float CurrentDef { get; protected set; }
    public float CurrentRes { get; protected set; }
    public float CurrentSpd { get; protected set; }
    #endregion

    public float RelativeSpd { get; protected set; } = 5;

    protected override void Start()
    {
        base.Start();
        if (data != null)
            SetBaseStats();

        if (GetComponentInChildren<EntityUIOverlayController>() != null)
        {
            GetComponentInChildren<EntityUIOverlayController>().SetValues();
        }
    }

    protected virtual void SetBaseStats()
    {
        Hp = data.Hp + Mathf.FloorToInt(lvl * data.HpGrowthRate);
        CurrentHp = Hp;

        Mp = data.Mp + Mathf.FloorToInt(lvl * data.MpGrowthRate);
        CurrentMp = Mp;

        Stm = data.Stm + Mathf.FloorToInt(lvl * data.StmGrowthRate);
        CurrentStm = Stm;

        Str = data.Str + Mathf.FloorToInt(lvl * data.StrGrowthRate);
        CurrentStr = Str;

        Mag = data.Mag + Mathf.FloorToInt(lvl * data.MagGrowthRate);
        CurrentMag = Mag;

        Def = data.Def + Mathf.FloorToInt(lvl * data.DefGrowthRate);
        CurrentDef = Def;

        Res = data.Res + Mathf.FloorToInt(lvl * data.ResGrowthRate);
        CurrentRes = Res;

        Spd = data.Spd + Mathf.FloorToInt(lvl * data.SpdGrowthRate);
        CurrentSpd = Spd;
    }

    public virtual void ApplyPhysicalDmg(float dmg, float defIgnored = 0)
    {
        float modifiedDmg = dmg - (CurrentDef * (1 - defIgnored));
        if (modifiedDmg > 0)
            ModifyHP(-modifiedDmg);
        print(CurrentHp + " / " + Hp);
    }

    public virtual void ApplyMagicDmg(float dmg, float resIgnored = 0)
    {
        float modifiedDmg = dmg - (CurrentRes * (1 - resIgnored));
        if (modifiedDmg > 0)
            ModifyHP(-modifiedDmg);
        print(CurrentHp + " / " + Hp);
    }

    #region Hp Functions
    public virtual void ResetHP()
    {
        CurrentHp = Hp;
    }

    public virtual void ModifyHP(float amt)
    {
        CurrentHp += amt;
        if (CurrentHp < 0) CurrentHp = 0;
        else if (CurrentHp > Hp) CurrentHp = Hp;
    }
    #endregion

    #region Mp Functions
    public virtual void ResetMP()
    {
        CurrentMp = Mp;
    }

    public virtual void ModifyMp(float amt)
    {
        CurrentMp += amt;
        if (CurrentMp < 0) CurrentMp = 0;
        else if (CurrentMp > Mp) CurrentMp = Mp;
    }
    #endregion

    #region Stm Functions
    public virtual void ResetStm()
    {
        CurrentStm = Stm;
    }

    public virtual void ModifyStm(float atm)
    {
        CurrentStm += atm;
        if (CurrentStm < 0) CurrentStm = 0;
        else if (CurrentStm > Stm) CurrentStm = Stm;
    }
    #endregion

    #region Str Functions
    public virtual void ResetStr()
    {
        CurrentStr = Str;
    }

    public virtual void ModifyStr(float amt)
    {
        CurrentStr += amt;
        if (CurrentStr < 0) CurrentStr = 0;
    }
    #endregion

    #region Mag Functions
    public virtual void ResetMag()
    {
        CurrentMag = Mag;
    }

    public virtual void ModifyMag(float amt)
    {
        CurrentMag += amt;
        if (CurrentMag < 0) CurrentMag = 0;
    }
    #endregion

    #region Def Functions
    public virtual void ResetDef()
    {
        CurrentDef = Def;
    }

    public virtual void ModifyDef(float amt)
    {
        CurrentDef += amt;
        if (CurrentDef < 0) CurrentDef = 0;
    }
    #endregion

    #region Res Functions
    public virtual void ResetRes()
    {
        CurrentRes = Res;
    }

    public virtual void ModifyRes(float amt)
    {
        CurrentRes += amt;
        if (CurrentRes < 0) CurrentRes = 0;
    }
    #endregion

    #region Spd Functions
    public virtual void ResetSpd()
    {
        CurrentSpd = Spd;
    }

    public virtual void ModifySpd(float amt)
    {
        CurrentSpd += amt;
        if (CurrentSpd < 0) CurrentSpd = 0;
    }
    #endregion
}
