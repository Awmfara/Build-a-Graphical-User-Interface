using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private string MainMenuScene = ("PrefabBuilder");
    
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("KeyisPressed");
            SceneManager.LoadScene(MainMenuScene);
        } 
    }
}
