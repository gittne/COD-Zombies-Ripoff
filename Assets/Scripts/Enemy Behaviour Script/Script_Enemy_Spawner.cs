using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Spawner : MonoBehaviour
{

    public int currentWaveIndex {  get; private set; } //A current wave number

    public Wave[] waves;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class Wave
    {
      public string waveName; 
      public GameObject[] Horde;// The amount of enemies on the board
      public float SpawnSpeed;

      public int waveAmount; // The Amount of waves in total
      public int enemiesLeft; // The amount of enemies still alive 
      public int currentHordeAmount; //the total amount of enemies in that round
      
    }

}
