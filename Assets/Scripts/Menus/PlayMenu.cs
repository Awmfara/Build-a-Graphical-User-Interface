using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject player;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindWithTag("Player");
    }
    public void SaveGame()
    {
        Save save = SaveGameStats();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/space.sav");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }
    private Save SaveGameStats()
    {
        Save save = new Save();
        gameManager.playerPosition = player.transform.position;
        save.playerHealth = gameManager.Health;
        save.currency = gameManager.Currency;
        save.playerX = gameManager.playerPosition.x;
        save.playerY = gameManager.playerPosition.y;
        save.playerZ = gameManager.playerPosition.z;
        Debug.Log(save.playerHealth);
        return save;
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/space.sav"))

        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/space.sav",
                                      FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
           
            SceneManager.LoadScene("GamePlay");

            gameManager.Health = save.playerHealth;
            gameManager.Currency = save.currency;
            gameManager.playerPosition = new Vector3(save.playerX, save.playerY, save.playerZ);
            gameManager.loadPoint = true;
            gameManager.iniTime = true;

            
            Debug.Log("GameIsLoaded");


        }

        else
        {
            Debug.Log("No Save File Exists");
        }
    }

}
