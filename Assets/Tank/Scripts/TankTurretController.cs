using UnityEngine;

public class TankTurretController : MonoBehaviour
{
    public float lookSpeed = 1.0f;

    public float minX = -40f;
    public float maxX = 40f;

    private float rotateX = 0f;

    void Update()
    {
        float lookX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;

        rotateX += lookX;
        rotateX = Mathf.Clamp(rotateX, minX, maxX);

        transform.localRotation = Quaternion.Euler(0f, rotateX, 0f);
    }
}
