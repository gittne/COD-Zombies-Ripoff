using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterMovement
{
    void Movement();
    void Look();
    void Jump();
    void Crouch();
    void Slide();
}

public interface CharacterStats
{
    void HealthCheck();
    void StaminaCheck();
}