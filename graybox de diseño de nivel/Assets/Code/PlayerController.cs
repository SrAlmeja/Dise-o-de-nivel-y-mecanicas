using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSensitivity = 2f;
    private float cameraRotation = 0f;
    private Camera playerCamera;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        playerRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

        cameraRotation -= mouseY;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
