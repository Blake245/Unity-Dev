using Unity.VisualScripting;
using UnityEngine;

public class Destructable : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 20;
    [SerializeField] GameObject destroyFx;

    [SerializeField] AudioClip audio;

    //bool destroyed = false;

    //private void Start()
    //{
    //    audio = GetComponent<AudioSource>();
    //}

    public float Health { get { return health; } set { health = (value < 0) ? 0 : value; } }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (tag == "Player")
            {
                //destroyed = true;
                if (destroyFx != null) Instantiate(destroyFx, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(audio, transform.position, 1);
                return;
            }
            //destroyed = true;
            if(destroyFx != null) Instantiate(destroyFx, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(audio, transform.position, 1);
            
            Destroy(gameObject);
        }
    }
}
