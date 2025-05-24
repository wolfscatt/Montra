using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Characters/Enemy")]
public class EnemyData : BaseCharacterData
{
    public List<SkillData> skills; // Düþmanýn özel saldýrýlarý
    public string aiPattern; // Basit AI tanýmý
    public int rewardGold; // Boss ödülü
}
