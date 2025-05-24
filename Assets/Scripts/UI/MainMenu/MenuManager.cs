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
        multiplayerButton.SetEnabled(false); // Multiplayer butonunu devre dýþý býrak
        settingsButton.clicked += OpenSettings;
        exitButton.clicked += ExitGame;
    }

    private void StartGame()
    {
        Debug.Log("Oyuna Baþla týklandý.");
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1); // "GameScene" yerine oyun sahnenin adýný yaz
    }

    private void OpenSettings()
    {
        Debug.Log("Ayarlar týklandý.");
        // Ayarlar için yeni bir UI Document oluþturulacak ve o açýlacak.
    }

    private void ExitGame()
    {
        Debug.Log("Çýkýþ týklandý.");
        Application.Quit();
    }
}
