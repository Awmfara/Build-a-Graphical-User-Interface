using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class OptionsMenu : MonoBehaviour
{
    #region Visual Parameters
    [Header("Visual Options")]
    [SerializeField, Tooltip("Toggles Full Screen")]
    private Toggle fullScreenToggle = null;
    public Resolution[] resolutions;
    public Dropdown resolution;


    #endregion

    private void Awake()
    {
        LoadPlayerPrefs();
    }
    private void Start()
    {
        SetupResolutions();

        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;
        }


    }

    /// <summary>
    /// Setups Resolution Options for Dropdown.
    /// Chooses Resolution Options from Screen Options
    /// Creates a string based on these options
    /// </summary>
    private void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
    }

    void SavePlayerPrefs()
    {

    }
    void LoadPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            fullScreenToggle.isOn = false;
        }
        else
        {
            fullScreenToggle.isOn = true;
        }
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
   
}
