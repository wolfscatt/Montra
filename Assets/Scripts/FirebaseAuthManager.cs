using Firebase.Auth;
using Firebase;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class FirebaseAuthManager : MonoBehaviour
{
    public static FirebaseAuthManager Instance { get; private set; }
    private FirebaseAuth auth;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                Debug.Log("Firebase hazır!");
            }
            else
            {
                Debug.LogError("Firebase başlatılamadı: " + task.Result);
            }
        });
    }

    public async Task<bool> Login(string email, string password)
    {
        try
        {
            var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
            Debug.Log("Giriş başarılı: " + result.User.Email);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Giriş başarısız: " + e.Message);
            return false;
        }
    }

    public async Task<bool> Register(string email, string password)
    {
        try
        {
            var result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            Debug.Log("Kayıt başarılı: " + result.User.Email);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Kayıt başarısız: " + e.Message);
            return false;
        }
    }
}
