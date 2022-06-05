using UnityEngine;

public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;
    [SerializeField] GameObject vidaPrefab;
    [SerializeField] GameObject obstaclePrefab;
    public float velocidad = 10f;

    Vector3 inicio;
    Vector3 fin;

    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

    private void Update ()
    {
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle ()
    {
        if (Random.Range(0, 5) !=1)
        {
            GameObject temp = Instantiate(obstaclePrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void SpawnCoins ()
    {

        if (Random.Range(0, 5) == 0)
        {
            GameObject temp = Instantiate(vidaPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}