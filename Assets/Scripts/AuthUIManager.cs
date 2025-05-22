using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AuthUIManager : MonoBehaviour
{
    public UIDocument loginUIDocument;
    public UIDocument registerUIDocument;

    private TextField loginEmailField;
    private TextField loginPasswordField;
    private TextField registerEmailField;
    private TextField registerPasswordField;
    private TextField registerRePasswordField;

    private void Awake()
    {
        // Baþlangýçta sadece register açýk
        loginUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        registerUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;

        SetupLoginUI();
        SetupRegisterUI();
    }

    void SetupLoginUI()
    {
        var root = loginUIDocument.rootVisualElement;

        loginEmailField = root.Q<TextField>("EmailField");
        loginPasswordField = root.Q<TextField>("PasswordField");
        var loginButton = root.Q<Button>("LoginBtn");

        var goToRegister = root.Q<Button>("GoToRegister");
        goToRegister.clicked += () => SwitchToRegister();

        loginButton.clicked += async () =>
        {
            string email = loginEmailField.text;
            string password = loginPasswordField.text;

            bool success = await FirebaseAuthManager.Instance.Login(email, password);
            if (success)
            {
                Debug.Log("Giriþ baþarýlý. Menü sahnesine geçiliyor...");
                SceneManager.LoadScene("MenuScene");
            }
        };
    }

    void SetupRegisterUI()
    {
        var root = registerUIDocument.rootVisualElement;

        registerEmailField = root.Q<TextField>("EmailField");
        registerPasswordField = root.Q<TextField>("PasswordField");
        registerRePasswordField = root.Q<TextField>("RePasswordField");

        var registerButton = root.Q<Button>("RegisterBtn");

        var goToLogin = root.Q<Button>("GoToLogin");
        goToLogin.clicked += () => SwitchToLogin();

        registerButton.clicked += async ()  =>
        {
            string email = registerEmailField.text;
            string password = registerPasswordField.text;
            string repassword = registerRePasswordField.text;

            if (password != repassword)
            {
                Debug.LogWarning("Þifreler uyuþmuyor!");
                return;
            }

            bool success = await FirebaseAuthManager.Instance.Register(email, password);
            if (success)
            {
                Debug.Log("Kayýt baþarýlý. Giriþ ekranýna geçiliyor.");
                SwitchToLogin();
            }
        };
    }

    public void SwitchToRegister()
    {
        loginUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        registerUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void SwitchToLogin()
    {
        registerUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        loginUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
