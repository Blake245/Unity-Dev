using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1, 10), Tooltip("change the speed")] public float speed = 2;
    public GameObject prefab;

    private void Awake()
    {
        print("Awake");
    }

    void Start()
    {
        print("Start");
    }

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        transform.position += velocity * speed * Time.deltaTime;

        // create prefab
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}
