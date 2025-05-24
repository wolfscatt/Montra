using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFillImage;
    [SerializeField] private Image healthBarTrailingFillImage;
    [SerializeField] private float trailDelay = 0.4f;
    [SerializeField] private float maxHealth = 100;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBarFillImage.fillAmount = 1f;
        healthBarTrailingFillImage.fillAmount = 1f;
    }

    private void Update()
    {
        // For testing purposes, drain health bar on space key press
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DrainHealthBar();
        }
    }

    private void DrainHealthBar()
    {
        currentHealth -= 10f;
        float ratio = currentHealth / maxHealth;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(healthBarFillImage.DOFillAmount(ratio, 0.25f))
            .SetEase(Ease.InOutSine);
        sequence.AppendInterval(trailDelay);

        sequence.Append(healthBarTrailingFillImage.DOFillAmount(ratio, 0.3f))
            .SetEase(Ease.InOutSine);

        sequence.Play();
    }

    public void SetMaxHealth(float max)
    {
        maxHealth = max;
        currentHealth = max;
        healthBarFillImage.fillAmount = 1f;
        healthBarTrailingFillImage.fillAmount = 1f;
    }

    public void UpdateHealth(float health)
    {
        currentHealth = health;
        float ratio = currentHealth / maxHealth;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(healthBarFillImage.DOFillAmount(ratio, 0.25f))
            .SetEase(Ease.InOutSine);
        sequence.AppendInterval(trailDelay);
        sequence.Append(healthBarTrailingFillImage.DOFillAmount(ratio, 0.3f))
            .SetEase(Ease.InOutSine);
        sequence.Play();
    }
}
