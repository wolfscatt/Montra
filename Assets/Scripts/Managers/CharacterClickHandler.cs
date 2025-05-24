using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterClickHandler : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol týklama
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                var character = hit.collider.GetComponent<IBattleCharacter>();
                if (character != null)
                {
                    Debug.Log("Clicked on: " + character.Name);
                    TurnManager.Instance.OnCharacterClicked(character);
                }
            }
        }
    }
}
