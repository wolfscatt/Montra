using System.Collections.Generic;

public class Enemy : BaseBattleCharacter
{
    private EnemyData enemy => characterData as EnemyData;
    public override bool IsEnemy() => true;
    public override List<SkillData> GetSkills() => enemy.skills;
}
