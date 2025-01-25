using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 3;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform Barrel;
    [SerializeField] TMP_Text ammoText;
    //[SerializeField] TMP_Text healthText;
    [SerializeField] Slider healthSlider;
    public int ammo = 10;
    //public int health = 3;

    float torque;
    float force;

    Rigidbody rb;
    Destructable destructable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destructable = GetComponent<Destructable>();
    }

    
    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Instantiate(rocket, Barrel.position, Barrel.rotation);
            ammo--;
        }

        ammoText.text = "Ammo: " + ammo.ToString();
        //healthText.text = "Health: " + health.ToString();
        healthSlider.value = destructable.Health;
        if (destructable.Health <= 0)
        {
            GameManager.Instance.SetGameOver();
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }

    public void ApplyDamage(float damage)
    {
        
    }
}
