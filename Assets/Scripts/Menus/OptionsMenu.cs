using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class OptionsMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Toggles Full Screen")]
    private Toggle fullScreenToggle = null;

    private void Awake()
    {
        LoadPlayerPrefs();
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;
        }
 
        
    }
    private void SavePlayerPrefs()
    {
        if(fullScreenToggle.isOn)
        {
            PlayerPrefs.SetInt("full")
        }
    }
    void LoadPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("fullscreen") ==0)
        {
            fullScreenToggle.isOn = false;
        }
        else
        {
            fullScreenToggle.isOn = true;
        }
    }
}
