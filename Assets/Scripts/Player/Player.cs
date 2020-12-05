using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager = null;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.loadPoint = true;
  
    }
    private void Update()
    {

        if (gameManager.loadPoint)
        {
            transform.position = gameManager.playerPosition;
            gameManager.loadPoint = false;

        }
  
    }



}
