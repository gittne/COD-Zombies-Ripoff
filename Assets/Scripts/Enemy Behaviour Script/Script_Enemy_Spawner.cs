using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Enemy_Spawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING}
    public int currentWaveIndex {  get; private set; } //A current wave number
    [SerializeField] Wave[] waves;

    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] int nextWave = 0;
    [SerializeField] float countDown;
  

    private float searchCountDown = 3f;


    private SpawnState state = SpawnState.WAITING;

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public GameObject[] Horde;// The amount of enemies on the board
        public float spawnRate;
        //public int waveAmount; // The Amount of waves in total
        public int currentHordeAmount; //the total amount of enemies in that round

    }

    // Start is called before the first frame update
    void Start()
    {
     countDown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive()) // check if enemy is dead
            {
                Debug.Log("Round Over");
            }
            else
            {
                return;
            }
        }

        if (countDown <= 0)
        {
            if (true)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));// starts the spawning
                    Debug.Log("Spawning");
                }
            }
        }
        else
        {
          countDown -= timeBetweenWaves;    
        }

    }
    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    

    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.currentHordeAmount; i++)   // Spawning
        {
            Instantiate(_wave.Horde[i], transform.position, transform.rotation);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }                                  

        state = SpawnState.WAITING;

        yield break;
    }

}
