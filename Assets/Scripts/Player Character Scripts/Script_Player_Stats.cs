using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Stats : MonoBehaviour, CharacterStats
{
    Script_Player_Movement_Singleplayer playerMovementScript;

    [Header("Health Variables")]
    [SerializeField] int health;
    public int characterHealth
    {
        get
        {
            return health;
        }
        private set
        {
            health = value;
        }
    }

    [Header("Stamina Variables")]
    [SerializeField] float stamina;
    public float characterStamina
    {
        get
        {
            return stamina;
        }
        private set
        {
            stamina = value;
        }
    }
    [SerializeField] float staminaRegenerationMultiplier;
    [SerializeField] float staminaDegenerationMultiplier;
    [SerializeField] float maxStamina;
    public float characterMaxStamina
    {
        get
        {
            return maxStamina;
        }
        private set
        {
            maxStamina = value;
        }
    }
    [SerializeField] float staminaReset;
    [SerializeField] float staminaResetThreshold;
    public bool isStaminaActivatable { get; private set; }

    public void HealthCheck()
    {

    }

    public void StaminaCheck()
    {
        if (Script_Player_Movement_Singleplayer.isSprinting && isStaminaActivatable)
        {
            stamina -= Time.deltaTime * staminaDegenerationMultiplier;
        }
        else
        {
            stamina += Time.deltaTime * staminaRegenerationMultiplier;

            if (stamina > maxStamina)
            {
                stamina = maxStamina;
            }
        }

        if (stamina <= 0)
        {
            isStaminaActivatable = false;
        }

        if (!isStaminaActivatable)
        {
            staminaReset += Time.deltaTime;

            if (staminaReset > staminaResetThreshold)
            {
                isStaminaActivatable = true;
                staminaReset = 0f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GetComponent<Script_Player_Movement_Singleplayer>();

        staminaReset = staminaResetThreshold - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        StaminaCheck();
    }
}
