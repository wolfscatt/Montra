using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Characters/Enemy")]
public class EnemyData : BaseCharacterData
{
    public List<SkillData> skills; // D��man�n �zel sald�r�lar�
    public string aiPattern; // Basit AI tan�m�
    public int rewardGold; // Boss �d�l�
}
