using UnityEngine;

public class CameraController : MonoBehaviour {

    public float mouseSensitivity = 100.0f;  // sensibilidad del mouse
    public Transform player;  // transform del objeto que seguirá la cámara
    float distance = 5.0f;  // distancia de la cámara al objeto
    float height = 2.0f;  // altura de la cámara sobre el objeto
    float rotationX = 0.0f;  // rotación en el eje horizontal de la cámara
    float rotationY = 0.0f;  // rotación en el eje vertical de la cámara

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;  // ocultar el cursor y mantenerlo en el centro de la pantalla
    }

    void LateUpdate() {
        // rotación de la cámara en función del movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);  // limitar la rotación vertical de la cámara

        // actualizar la rotación de la cámara y su posición
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0.0f);
        transform.position = player.position - transform.forward * distance + Vector3.up * height;
    }
}