using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int strenght, defense;
    public int level, currentExp, expToLevel;
    public int maxHP, currentHP;
    public DungeonWeaponController.weaponType currentWeapon;
    public string currentLevel;
}
