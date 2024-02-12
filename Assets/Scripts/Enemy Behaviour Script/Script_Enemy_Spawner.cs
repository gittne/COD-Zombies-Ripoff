using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Spawner : MonoBehaviour
{

    public int currentWaveIndex {  get; private set; } //A current wave number

    [SerializeField] GameObject[] Horde;

    [SerializeField] int waveAmount; // The Amount of waves in total
    [SerializeField] int enemiesLeft; // The amount of enemies still alive 
    [SerializeField] int currentHordeAmount; //the total amount of enemies in that round
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
