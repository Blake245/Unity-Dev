using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float force = 10;
    //[SerializeField]  FXTrail;
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);
    }

}
