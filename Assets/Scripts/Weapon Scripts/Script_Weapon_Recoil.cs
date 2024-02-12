using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Recoil : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 targetRotation;

    public void Recoil(float xRecoil, float yRecoil, float zRecoil)
    {
        targetRotation += new Vector3(-xRecoil, Random.Range(-yRecoil, yRecoil), Random.Range(-zRecoil, zRecoil));
    }

    public void ResetView(float snapBack, float returnSpeed)
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snapBack * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
