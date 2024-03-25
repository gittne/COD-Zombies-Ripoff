using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Movement_Singleplayer : MonoBehaviour, CharacterMovement
{
    Script_Player_Stats playerStatsScript;

    [Header("Camera Variables")]
    [SerializeField] float sensitivity;
    [SerializeField] Camera playerCamera;
    [SerializeField] float maxClampValue;
    float xRotation;
    float fovStandardValue;

    [Header("FOV Variables")]
    [SerializeField] float fovValueChangeAmount;
    [SerializeField] float fovValueEasingTime;
    [SerializeField] AnimationCurve fovEasingCurve;
    float fovIncreaseElapsedTime;
    float fovDecreaseElapsedTime;

    [Header("Movement Variables")]
    [SerializeField] float walkingSpeed;
    [SerializeField] float runningSpeed;
    CharacterController controller;

    [Header("Weapon Transform Variables")]
    [SerializeField] Transform weaponHolderTransform;
    [SerializeField] float weaponRotationSwitchEasingTime;
    [SerializeField] float weaponPositionSwitchEasingTime;
    [SerializeField] Quaternion weaponSprintRotation;
    [SerializeField] Vector3 weaponSprintPosition;
    [SerializeField] AnimationCurve weaponPositionEasingCurve;
    float weaponLoweringElapsedTime;
    float weaponRaisingElapsedTime;

    public static bool isSprinting => Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Vertical") > 0;

    public void Look()
    {
        xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -maxClampValue, maxClampValue);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
    }

    public void Movement()
    {
        float sidewaysMovement = Input.GetAxisRaw("Horizontal");
        float forwardMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * sidewaysMovement + transform.forward * forwardMovement;

        controller.Move(movement.normalized * (isSprinting && playerStatsScript.isStaminaActivatable ? runningSpeed : walkingSpeed) * Time.deltaTime);
    }

    void CameraFovChange(Camera camera, bool isSprinting, bool isStaminaActivatable, float fovStandardValue, float fovValueChange)
    {
        if (isSprinting && isStaminaActivatable)
        {
            fovIncreaseElapsedTime += Time.deltaTime;
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, fovStandardValue + fovValueChange, fovEasingCurve.Evaluate(fovIncreaseElapsedTime / fovValueEasingTime));
            fovDecreaseElapsedTime = 0;
        }
        else if (!isStaminaActivatable)
        {
            fovDecreaseElapsedTime += Time.deltaTime;
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, fovStandardValue, fovEasingCurve.Evaluate(fovDecreaseElapsedTime / fovValueEasingTime));
            fovIncreaseElapsedTime = 0;
        }
        else
        {
            fovDecreaseElapsedTime += Time.deltaTime;
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, fovStandardValue, fovEasingCurve.Evaluate(fovDecreaseElapsedTime / fovValueEasingTime));
            fovIncreaseElapsedTime = 0;
        }
    }

    void WeaponHolderSprintTransform(Transform transform, bool isSprinting, bool isStaminaActivatable, Quaternion newRotation, Vector3 newPosition)
    {
        if (isSprinting && isStaminaActivatable)
        {
            weaponLoweringElapsedTime += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(new Quaternion(0, 0, 0, 1), newRotation, weaponPositionEasingCurve.Evaluate(weaponLoweringElapsedTime / weaponRotationSwitchEasingTime));
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, weaponPositionEasingCurve.Evaluate(weaponLoweringElapsedTime / weaponPositionSwitchEasingTime));
            weaponRaisingElapsedTime = 0;
        }
        else if (!isStaminaActivatable)
        {
            weaponRaisingElapsedTime += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(newRotation, new Quaternion(0, 0, 0, 1), weaponPositionEasingCurve.Evaluate(weaponRaisingElapsedTime / weaponRotationSwitchEasingTime));
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), weaponPositionEasingCurve.Evaluate(weaponRaisingElapsedTime / weaponPositionSwitchEasingTime));
            weaponLoweringElapsedTime = 0;
        }
        else
        {
            weaponRaisingElapsedTime += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(newRotation, new Quaternion(0, 0, 0, 1), weaponPositionEasingCurve.Evaluate(weaponRaisingElapsedTime / weaponRotationSwitchEasingTime));
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), weaponPositionEasingCurve.Evaluate(weaponRaisingElapsedTime / weaponPositionSwitchEasingTime));
            weaponLoweringElapsedTime = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fovStandardValue = playerCamera.fieldOfView;

        controller = GetComponent<CharacterController>();
        playerStatsScript = GetComponent<Script_Player_Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Movement();
        CameraFovChange(playerCamera, isSprinting, playerStatsScript.isStaminaActivatable, fovStandardValue, fovValueChangeAmount);
        WeaponHolderSprintTransform(weaponHolderTransform, isSprinting, playerStatsScript.isStaminaActivatable, weaponSprintRotation, weaponSprintPosition);
    }
}
