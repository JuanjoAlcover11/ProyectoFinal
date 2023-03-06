using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance PlayerStats;

    public int currentScore;

    void Awake()
    {
        if (PlayerStats == null)
        {
            PlayerStats = this;
            // The instance doesnt get destroyed when we change scenes
            DontDestroyOnLoad(PlayerStats);
        }
        else
        {
            // If the instance already exists, we destroy it 
            Destroy(this);
        }
    }


    void Start()
    {
        currentScore = PlayerPrefs.GetInt("SCORE");
        //Score points
    }


    public void SaveStats()
    {//We save the score
        PlayerPrefs.SetInt("SCORE", currentScore);
    }
}
