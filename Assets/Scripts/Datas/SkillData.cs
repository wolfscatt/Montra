using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public int power;
    public SkillType type; // Attack, Heal, Buff, Debuff gibi
    public Sprite skillIcon;
}

public enum SkillType { Attack, Heal, Buff, Debuff }