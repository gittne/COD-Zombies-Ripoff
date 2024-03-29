using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterMovement
{
    void Movement();
    void Look();
}

public interface CharacterStats
{
    void HealthCheck();
    void StaminaCheck();
}