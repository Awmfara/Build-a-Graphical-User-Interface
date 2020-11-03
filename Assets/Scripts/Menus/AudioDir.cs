using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioDir : MonoBehaviour
{
    #region MouseClicks
    [Header("Mouse Click")]
    [SerializeField, Tooltip("Assign to Audio Sources>SFX>MouseClick")]
    private AudioSource mouseClickSource = null;
    [SerializeField, Tooltip("Assign to Assets>Audio>MouseClick")]
    private AudioClip mouseClickClip = null;
    [SerializeField, Tooltip("Volume of Mouse Click")]
    private float mouseClickVolume = 1f;
    #endregion
    #region Faders
    [Header("Mixer")]
    [SerializeField, Tooltip("Assign to Mixer")]
    private AudioMixer mixer = null;
    [SerializeField, Tooltip("Assign to Music Slider in Options")]
    private Slider musicVol = null;
    [SerializeField, Tooltip("Assign to Mixer Music")]
    private string musicMixer = ("musicMixer");
    [SerializeField, Tooltip("Assign to SFX Slider in Options")]
    private Slider sfxVol = null;
    [SerializeField, Tooltip("Assign to Mixer SFX")]
    private string sfxMixer = ("sfxMixer");
    [SerializeField, Tooltip("Assign to Master Slider in Options")]
    private Toggle masterVol = null;
    [SerializeField, Tooltip("Assign to masterMixer ")]
    private string masterMixer = ("masterMixer");
    #endregion

    private void Awake()
    {
        MixerSetupMeth();

    }



    /// <summary>
    /// Plays Mouse Click Sound
    /// 
    /// </summary>
    void Update()
    {
        MouseClickMeth();
    }
    /// <summary>
    /// Setups Mixer and Fader Functions in the audio menu
    /// Gets from playerprefs converts to logarithmic value
    /// Adds Listener for any changes in volume
    /// </summary>
    private void MixerSetupMeth()
    {
        float savedMusVol = PlayerPrefs.GetFloat(musicMixer, musicVol.maxValue);
        SetVolume(musicMixer, savedMusVol);
        musicVol.value = savedMusVol;
        musicVol.onValueChanged.AddListener((float _) => SetVolume(musicMixer, _));

        float savedSfxVol = PlayerPrefs.GetFloat(sfxMixer, sfxVol.maxValue);
        SetVolume(sfxMixer, savedSfxVol);
        sfxVol.value = savedSfxVol;
        sfxVol.onValueChanged.AddListener((float _) => SetVolume(sfxMixer, _));
    }
    /// <summary>
    /// Sets Volumme of Mixer using ConvertToDecibel function
    /// </summary>
    /// <param name="_mixer">Assign to Mixer Parameter</param>
    /// <param name="_vol">Assign</param>
    void SetVolume(string _mixer, float _vol)
    {
        mixer.SetFloat(_mixer, ConvertToDecibel(_vol / musicVol.maxValue));
        PlayerPrefs.SetFloat(_mixer, _vol);
    }
    private float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }
    private void MouseClickMeth()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickSource.PlayOneShot(mouseClickClip, mouseClickVolume);
        }
    }
    public void MuteAudio(bool isMuted)
    {
        if (isMuted)
        {
            mixer.SetFloat("masterMixer", -80);
        }
        else
        {
            mixer.SetFloat("masterMixer", 0);
        }
    }

}
