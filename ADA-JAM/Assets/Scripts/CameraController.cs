using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 2f;
    public float distance = 4f;
    public float height = 1.5f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        var delta = Mouse.current.delta.ReadValue();
        float mouseX = delta.x * 0.05f;
        float mouseY = delta.y * 0.05f;

        yaw   += mouseX * sensitivity;
        pitch -= mouseY * sensitivity;
        pitch  = Mathf.Clamp(pitch, -20f, 60f);

        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        transform.position = target.position - rot * Vector3.forward * distance + Vector3.up * height;
        transform.LookAt(target.position + Vector3.up * 0.5f);

        target.root.rotation = Quaternion.Euler(0, yaw, 0);
    }
}