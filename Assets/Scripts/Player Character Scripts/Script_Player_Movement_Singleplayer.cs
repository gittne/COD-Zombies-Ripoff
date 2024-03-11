using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Movement_Singleplayer : MonoBehaviour, CharacterMovement
{
    [Header("Camera Variables")]
    [SerializeField] float sensitivity;
    [SerializeField] Camera playerCamera;
    [SerializeField] float maxClampValue;
    float xRotation;

    [Header("Movement Variables")]
    [SerializeField] float walkingSpeed;
    [SerializeField] float runningSpeed;
    CharacterController controller;

    public static bool isSprinting => Input.GetKey(KeyCode.LeftShift);

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

        controller.Move(movement.normalized * (isSprinting ? runningSpeed : walkingSpeed) * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Movement();
    }
}
