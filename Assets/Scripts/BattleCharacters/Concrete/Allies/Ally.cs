using System.Collections.Generic;

public class Ally : BaseBattleCharacter
{
    private AllyData ally => characterData as AllyData;
    public override bool IsEnemy() => false;
    public override List<SkillData> GetSkills() => ally.skills;
}
