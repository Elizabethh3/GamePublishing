using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction moveAction, rotateAction;

    Vector2 moveValue, rotateValue;

    public float movementSpeed, rotationSpeed;
    Rigidbody rigidBody;
    [SerializeField] Camera thirdPerson;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponentInParent<Rigidbody>();
        movementSpeed = 6.0f;
        rotationSpeed = 100.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        //move
        Vector3 moveDirection = transform.forward * moveValue.y + transform.right * moveValue.x;
        Vector3 newPosition = rigidBody.position + moveDirection * movementSpeed * Time.fixedDeltaTime;

        rigidBody.MovePosition(newPosition);

        //rotate
        Quaternion rotation = Quaternion.Euler(0f, rotateValue.x * rotationSpeed * Time.fixedDeltaTime, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * rotation);
    }

    
    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }
}