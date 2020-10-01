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
    [SerializeField,Tooltip("Volume of Mouse Click")]
    private float mouseClickVolume = 1f;
    #endregion
    #region Faders
    [Header("Mixer")]
    [SerializeField, Tooltip("Assign to Mixer")]
    private AudioMixer mixer = null;
    [SerializeField, Tooltip("Assign to Music Slider in Options")]
    private Slider musicVol=null;
    [SerializeField, Tooltip("Assign to Mixer Music")]
    private string musicMixer=("musicMixer");
    [SerializeField, Tooltip("Assign to SFX Slider in Options")]
    private Slider sfxVol=null;
    [SerializeField, Tooltip("Assign to Mixer SFX")]
    private string sfxMixer=("sfxMixer");
    #endregion

    private void Awake()
    {
        float savedMusVol = PlayerPrefs.GetFloat(musicMixer, musicVol.maxValue);
        SetVolume(musicMixer,savedMusVol);
        musicVol.value = savedMusVol;
        musicVol.onValueChanged.AddListener((float _) => SetVolume(musicMixer,_));

    

    }
    /// <summary>
    /// Plays Mouse Click Sound
    /// 
    /// </summary>
    void Update()
    {
        MouseClickMeth();
    }
    
    void SetVolume(string _mixer,float _vol)
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
   
}
