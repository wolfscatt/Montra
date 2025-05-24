using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAlly", menuName = "Characters/Ally")]
public class AllyData : BaseCharacterData
{
    public List<SkillData> skills; // Oyuncu karakterinin �zel becerileri
    public string characterClass; // �r: Warrior, Mage
}
