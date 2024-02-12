using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Recoil : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 targetRotation;

    [SerializeField] float snapBack;
    [SerializeField] float returnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snapBack * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void Recoil(float xRecoil, float yRecoil, float zRecoil)
    {
        targetRotation += new Vector3(-xRecoil, Random.Range(-yRecoil, yRecoil), Random.Range(-zRecoil, zRecoil));
    }
}
