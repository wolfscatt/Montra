using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBattleCharacter : MonoBehaviour, IBattleCharacter
{
    [SerializeField] protected BaseCharacterData characterData;
    protected SpriteRenderer spriteRenderer;
    [SerializeField] private HealthBar healthBar; // Saðlýk barý referansý

    public string Name => characterData.characterName;
    public int CurrentHP { get; protected set; }
    public int MaxHP => characterData.maxHP;
    public int AttackPower => characterData.attackPower;

    public virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = characterData.characterSprite;
        CurrentHP = MaxHP;
        healthBar.SetMaxHealth(MaxHP); // Max HP'yi ayarla
        healthBar.UpdateHealth(CurrentHP); // Baþlangýçta dolu göster
    }

    public virtual void TakeDamage(int amount)
    {
        CurrentHP = Mathf.Max(0, CurrentHP - amount);
        healthBar.UpdateHealth(CurrentHP);
    }

    public virtual void Heal(int amount)
    {
        CurrentHP = Mathf.Min(MaxHP, CurrentHP + amount);
        healthBar.UpdateHealth(CurrentHP);
    }

    public bool IsAlive() => CurrentHP > 0;
    public abstract bool IsEnemy();
    public abstract List<SkillData> GetSkills(); // Yeteneði döndürecek
}
