using Unity.VisualScripting;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] bool destroyOnhit = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamagable component))
        {
            component.ApplyDamage(damage);
        }

        if(destroyOnhit )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable component))
        {
            component.ApplyDamage(damage * Time.deltaTime);
        }
    }
}
