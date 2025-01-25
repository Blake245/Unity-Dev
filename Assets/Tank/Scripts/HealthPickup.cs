using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthAmount = 1;
    [SerializeField] GameObject pickupFX;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerTank component))
            {
                //component.health += healthAmount;
                Destroy(gameObject);
                if (pickupFX != null)
                {
                    Instantiate(pickupFX, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
