using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Recoil : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 targetRotation;
    CharacterController playerController;

    void Start()
    {
        playerController = GetComponentInParent<CharacterController>();
    }

    public void Recoil(float xRecoil, float yRecoil, float zRecoil, float movementPenalty)
    {
        targetRotation += new Vector3(-xRecoil + (-Mathf.Abs(playerController.velocity.x) * movementPenalty) 
            + (-Mathf.Abs(playerController.velocity.z) * movementPenalty), 
            Random.Range(-yRecoil, yRecoil), Random.Range(-zRecoil, zRecoil)) ;
    }

    public void ResetView(float snapBack, float returnSpeed)
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snapBack * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
