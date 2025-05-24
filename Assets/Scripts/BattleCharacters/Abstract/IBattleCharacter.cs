using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleCharacter 
{
    string Name { get; }
    int CurrentHP { get; }
    int MaxHP { get; }
    int AttackPower { get; }

    void TakeDamage(int amount);
    void Heal(int amount);
    bool IsAlive();
    bool IsEnemy();
    List<SkillData> GetSkills(); 
}
