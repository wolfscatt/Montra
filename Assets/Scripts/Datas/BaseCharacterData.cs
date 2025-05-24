using UnityEngine;

public abstract class BaseCharacterData : ScriptableObject
{
    public string characterName;
    public int maxHP;
    public int attackPower;
    public Sprite characterSprite;
}
