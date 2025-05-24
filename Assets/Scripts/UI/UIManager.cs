using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Transform skillPanel; // Skill butonlar�n�n bulundu�u panel
    public GameObject skillButtonPrefab; // Skill buton prefab'�

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowSkills(List<SkillData> skills)
    {
        // Paneli temizle
        foreach (Transform child in skillPanel)
        {
            Destroy(child.gameObject);
        }

        // Her skill i�in buton olu�tur
        foreach (SkillData skill in skills)
        {
            GameObject buttonObj = Instantiate(skillButtonPrefab, skillPanel);
            Button button = buttonObj.GetComponent<Button>();
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();

            buttonText.text = skill.skillName;
            button.onClick.AddListener(() => TurnManager.Instance.OnSkillSelected(skill));
        }
    }

    public void HideSkills()
    {
        foreach (Transform child in skillPanel)
        {
            Destroy(child.gameObject);
        }
    }
}
