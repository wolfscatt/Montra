using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public UIDocument menuUIDocument;

    private void Start()
    {
        var root = menuUIDocument.rootVisualElement;

        var startGameButton = root.Q<Button>("StartGameBtn");
        var multiplayerButton = root.Q<Button>("MultiplayerBtn");
        var settingsButton = root.Q<Button>("SettingsBtn");
        var exitButton = root.Q<Button>("ExitBtn");

        startGameButton.clicked += StartGame;
        multiplayerButton.SetEnabled(false); // Multiplayer butonunu devre d��� b�rak
        settingsButton.clicked += OpenSettings;
        exitButton.clicked += ExitGame;
    }

    private void StartGame()
    {
        Debug.Log("Oyuna Ba�la t�kland�.");
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1); // "GameScene" yerine oyun sahnenin ad�n� yaz
    }

    private void OpenSettings()
    {
        Debug.Log("Ayarlar t�kland�.");
        // Ayarlar i�in yeni bir UI Document olu�turulacak ve o a��lacak.
    }

    private void ExitGame()
    {
        Debug.Log("��k�� t�kland�.");
        Application.Quit();
    }
}
