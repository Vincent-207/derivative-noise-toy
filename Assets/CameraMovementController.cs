using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovementController : MonoBehaviour
{
    public InputActionReference toggleCursorInput, moveInput, lookInput, speedIncrease, speedDecrease;
    [SerializeField] private bool isMovementEnabled = false;
    [SerializeField] private Vector2 a;
    [SerializeField] [Range(0, 1)] private float lookSensitivity;
    [SerializeField] private float moveSpeed;
    void Update()
    {
        if (isMovementEnabled) DoMovement();
    }

    void DoMovement()
    {
        Vector2 moveInputVec = a = moveInput.action.ReadValue<Vector2>();
        transform.position += (transform.forward * moveInputVec.y + transform.right * moveInputVec.x) * moveSpeed * Time.deltaTime;
        
        Vector2 lookInputVec = lookInput.action.ReadValue<Vector2>();
        lookInputVec *= lookSensitivity;
        Vector3 currentRot =  transform.eulerAngles;
        Vector3 newRot = transform.eulerAngles + new Vector3(-lookInputVec.y, lookInputVec.x);
        transform.eulerAngles = newRot;
    }
    void OnEnable()
    {
        lookInput.action.Disable();
        lookInput.action.Enable();
        moveInput.action.Disable();
        moveInput.action.Enable();
        toggleCursorInput.action.Disable();
        toggleCursorInput.action.Enable();
        toggleCursorInput.action.started += ToggleCursor;
        
        speedDecrease.action.Enable();
        speedDecrease.action.started += DecreaseSpeed;
        speedIncrease.action.Enable();
        speedIncrease.action.started += IncreaseSpeed;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isMovementEnabled = false;

        moveSpeed = 5;

    }

    void DecreaseSpeed(InputAction.CallbackContext context)
    {
        moveSpeed /= 2;
    }

    void IncreaseSpeed(InputAction.CallbackContext context)
    {
        moveSpeed *= 2;
    }
    void ToggleCursor(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed!");
        if(Cursor.visible) Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
        isMovementEnabled =  !isMovementEnabled;
    }

    void OnDisable()
    {
        toggleCursorInput.action.started -= ToggleCursor;
        toggleCursorInput.action.Disable();
        
        speedDecrease.action.started -= DecreaseSpeed;
        speedDecrease.action.Disable();
        
        speedIncrease.action.started -= IncreaseSpeed;
        speedIncrease.action.Disable();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    
}
