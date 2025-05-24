using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public static TurnManager Instance { get; private set; }

    public TurnState currentState;
    public IBattleCharacter selectedCharacter;
    public IBattleCharacter selectedTarget;
    private SkillData selectedSkill;

    private List<IBattleCharacter> allCharacters;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        allCharacters = FindObjectsOfType<MonoBehaviour>().OfType<IBattleCharacter>().ToList();
        StartPlayerTurn();
        UIManager.Instance.HideSkills(); // Baþlangýçta skill panelini gizle
    }

    public void StartPlayerTurn()
    {
        currentState = TurnState.PlayerSelect;
        Debug.Log("Player turn: Select character.");
    }
    public void OnCharacterClicked(IBattleCharacter character)
    {
        if (currentState == TurnState.PlayerSelect && !character.IsEnemy())
        {
            selectedCharacter = character;
            currentState = TurnState.ActionSelect;
            Debug.Log("Selected character: " + character.Name);
            // UI'da skill butonlarýný açabilirsin
            UIManager.Instance.ShowSkills(character.GetSkills()); // Seçilen karakterin skillerini göster
        }
        else if (currentState == TurnState.TargetSelect)
        {
            if ((selectedSkill.type == SkillType.Attack && character.IsEnemy()) ||
                (selectedSkill.type == SkillType.Heal && !character.IsEnemy()))
            {
                selectedTarget = character;
                ResolveAction();
            }
            else
            {
                Debug.LogWarning("Invalid target for action!");
            }
        }
    }
    public void OnSkillSelected(SkillData skill)
    {
        if (currentState == TurnState.ActionSelect)
        {
            selectedSkill = skill;
            currentState = TurnState.TargetSelect;
            Debug.Log("Selected skill: " + skill.skillName);
        }
    }

    private void ResolveAction()
    {
        currentState = TurnState.ActionResolve;
        UIManager.Instance.HideSkills(); // Skill panelini gizle

        if (selectedSkill.type == SkillType.Attack)
        {
            selectedTarget.TakeDamage(selectedSkill.power);
            Debug.Log($"{selectedCharacter.Name} used {selectedSkill.skillName} on {selectedTarget.Name}");
        }
        else if (selectedSkill.type == SkillType.Heal)
        {
            selectedTarget.Heal(selectedSkill.power);
            Debug.Log($"{selectedCharacter.Name} used {selectedSkill.skillName} on {selectedTarget.Name}");
        }

        // Tur düþmana geçer
        Invoke(nameof(StartEnemyTurn), 2f); // Basit gecikme ile
    }

    private void StartEnemyTurn()
    {
        currentState = TurnState.EnemyTurn;
        Debug.Log("Enemy Turn");

        var enemies = allCharacters.Where(c => c.IsEnemy() && c.IsAlive()).ToList();
        var allies = allCharacters.Where(c => !c.IsEnemy() && c.IsAlive()).ToList();

        if (enemies.Count > 0 && allies.Count > 0)
        {
            var enemy = enemies[Random.Range(0, enemies.Count)];
            var target = allies[Random.Range(0, allies.Count)];
            var enemySkill = enemy.GetSkills().FirstOrDefault(s => s.type == SkillType.Attack);

            if (enemySkill != null)
            {
                target.TakeDamage(enemySkill.power);
                Debug.Log($"{enemy.Name} used {enemySkill.skillName} on {target.Name}");
            }
        }

        Invoke(nameof(StartPlayerTurn), 2f); // Tur oyuncuya döner
    }
}
    
