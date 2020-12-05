using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("PlayerHealth"), Range(0, 100)]
    private float health = 100;
    [SerializeField, Tooltip("Currency"), Range(0, 100)]
    private float currency = 100;
    [SerializeField, Tooltip("PlayerPosition")]
    public Vector3 playerPosition;
    [SerializeField, Tooltip("PlayerHealth"), Range(0, 100)]
    private float initalHealth = 100;
    [SerializeField, Tooltip("Currency"), Range(0, 100)]
    private float initialCurrency = 100;
    [SerializeField, Tooltip("PlayerPosition")]
    public Vector3 initalPlayerPosition;
    public bool loadPoint;
    public bool iniTime;
    #endregion

    #region Properties
    public float Health { get { return health; } set { health = value; } }
    public float Currency { get { return currency; } set { currency = value; } }
    #endregion

    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void ResetValues()
    {
        playerPosition = initalPlayerPosition;
        health = initalHealth;
        currency = initialCurrency;
    }
}
