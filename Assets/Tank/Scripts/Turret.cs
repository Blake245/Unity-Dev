using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] Transform barrel;
    [SerializeField] Transform player;
    [SerializeField, Range(0.5f, 5)] float spawnTime;
    [SerializeField] float spawnDistance = 50;

    float spawnTimer;
    Coroutine firecr;

    void Start()
    {
        //spawnTimer = Time.time + spawnTime;
        firecr = StartCoroutine(SpawnFire());
    }

    
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            // Only fires rockets when player is close to turret
            if (distance > spawnDistance)
            {
                if (firecr != null)
                {
                    StopCoroutine(firecr);
                    firecr = null;
                    //Debug.Log("Greater");
                }
            }
            else if (firecr == null)
            {
                firecr = StartCoroutine(SpawnFire());
                // Debug.Log("Less");
            }
            //Debug.Log($"distance: {distance}");
        }
        else
        {
            if (firecr != null)
            {
                StopCoroutine(firecr);
                firecr = null;
            }
        }
    }

    IEnumerator SpawnFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(rocketPrefab, barrel.transform.position, barrel.rotation);
        }
    }
}
