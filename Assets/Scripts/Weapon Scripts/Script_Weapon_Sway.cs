using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Sway : MonoBehaviour
{
    Script_Weapon_Activation currentWeapon;

    Vector3 swayPosition;
    Vector3 swayRotation;
    CharacterController controller;

    float speedCurve;
    float sinCurve { get => Mathf.Sin(speedCurve); }
    float cosCurve { get => Mathf.Cos(speedCurve); }
    Vector3 travelLimit;
    Vector3 bobLimit;
    Vector3 bobPosition;
    Vector3 bobRotation;
    float horizontalInput;
    float verticalInput;
    Vector2 horizontalVerticalInput;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = GetComponentInParent<Script_Weapon_Activation>();
        controller = GetComponentInParent<CharacterController>();

        travelLimit = Vector3.one * currentWeapon.currentWeaponData.bobTravelLimit;
        bobLimit = Vector3.one * currentWeapon.currentWeaponData.bobLimit;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        horizontalVerticalInput.x = horizontalInput;
        horizontalVerticalInput.y = verticalInput;

        SwayPositionCalculation(currentWeapon.currentWeaponData.swayStep, currentWeapon.currentWeaponData.swayMaxStepDistance);
        SwayRotationCalculation(currentWeapon.currentWeaponData.rotationStep, currentWeapon.currentWeaponData.swayMaxStepRotation);
        SwayApplication();
        BobOffsetApplication(controller);
        BobRotationApplication(currentWeapon.currentWeaponData.bobMultiplier, speedCurve);
        BobApplication(controller);
    }

    void SwayPositionCalculation(float step, float maxStepDistance)
    {
        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        Vector3 invertLook = new Vector3(xMouse, yMouse, 0) * -step;

        invertLook.x = Mathf.Clamp(invertLook.x, -maxStepDistance, maxStepDistance);
        invertLook.y = Mathf.Clamp(invertLook.y, -maxStepDistance, maxStepDistance);

        swayPosition = invertLook;
    }

    void SwayRotationCalculation(float rotationStep, float maxRotationStep)
    {
        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        Vector2 invertLook = new Vector2(xMouse, -yMouse) * -rotationStep;

        invertLook.x = Mathf.Clamp(invertLook.x, -maxRotationStep, maxRotationStep);
        invertLook.y = Mathf.Clamp(invertLook.y, -maxRotationStep, maxRotationStep);

        swayRotation = new Vector3(invertLook.y, invertLook.x, invertLook.x);
    }

    void SwayApplication()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, swayPosition, currentWeapon.currentWeaponData.swaySmoothing * Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(swayRotation), currentWeapon.currentWeaponData.swaySmoothing * Time.deltaTime);
    }

    void BobOffsetApplication(CharacterController controller)
    {
        float walkingInput = Input.GetAxisRaw("Horizontal");

        speedCurve += Time.deltaTime * (controller.isGrounded ? controller.velocity.magnitude : 1f) + 0.01f;

        bobPosition.x = (cosCurve * bobLimit.x * (controller.isGrounded ? 1 : 0)) - (walkingInput * travelLimit.x);

        bobPosition.y = (sinCurve * bobLimit.y) - (controller.velocity.y * travelLimit.y);

        bobPosition.z = - (controller.velocity.y * travelLimit.z);
    }

    void BobRotationApplication(Vector3 multiplier, float curveSpeed)
    {
        bobRotation.x = (horizontalVerticalInput != Vector2.zero ?
            multiplier.x * (Mathf.Sin(2 * curveSpeed)) : multiplier.x * (Mathf.Sin(2 * curveSpeed)) / 2);

        bobRotation.y = (horizontalVerticalInput != Vector2.zero ? multiplier.y * cosCurve : 0);

        bobRotation.z = (horizontalVerticalInput != Vector2.zero ? multiplier.z * cosCurve * horizontalVerticalInput.x : 0);
    }

    void BobApplication(CharacterController controller)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, bobPosition, (controller.velocity.magnitude > 0.1f ? controller.velocity.magnitude * Time.deltaTime : currentWeapon.currentWeaponData.bobSmoothing * Time.deltaTime));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(bobRotation), (controller.velocity.magnitude > 0.1 ? controller.velocity.magnitude * Time.deltaTime : currentWeapon.currentWeaponData.bobSmoothingRotation * Time.deltaTime));
    }
}
