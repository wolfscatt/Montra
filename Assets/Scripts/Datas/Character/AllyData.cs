using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAlly", menuName = "Characters/Ally")]
public class AllyData : BaseCharacterData
{
    public List<SkillData> skills; // Oyuncu karakterinin özel becerileri
    public string characterClass; // Ör: Warrior, Mage
}
