using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// # symbol stands for compiler commands
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{

    [SerializeField] TMP_InputField nameField;

    public string userName;

    private void Update()
    {
        userName = nameField.text;
    }

    public void StartNewGame()
    {
        // Once game is started, save userName field into persisting SaveManager data
        SaveManager.Instance.playerName = userName;
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
