using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;// allows for functions in Unity Editor
using UnityEngine.SceneManagement;//allows loading of scenes

public class MainMenu : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    [SerializeField, Tooltip("Type in Name of Opening Game Scene")]
    public string LoadScene = "GameScene";

    #endregion

    /// <summary>
    /// Loads the opening Scene of the Game
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(LoadScene);
    }
    /// <summary>
    /// Quits Application. If in Unity Editor, exits PlayMode
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR // if In Unity Editor
        EditorApplication.ExitPlaymode(); //Exits Playmode
#endif
        Application.Quit(); //Quits Application
    }
}
