using UnityEngine;

public class PinRotater : MonoBehaviour {

    public bool isActive = true;
    public float speed = 100f;
    public GameObject pinPrefab;
    private bool collided = false;
    private Transform nextPoint;

    private PointSpawner pointSpawner;
    private Vector3[] rotations = new Vector3[2] {Vector3.forward, Vector3.back };
    private int randRotation;

    private void Awake()
    {
        pointSpawner = FindObjectOfType<PointSpawner>();
        pinPrefab = this.gameObject;
    }

    private void Start()
    {
        randRotation = Random.Range(0, 2);  
    }

    void Update () {
        if (pointSpawner.isRoundActive)
        {
            if (isActive)
            {
                transform.Rotate(rotations[randRotation] * speed * Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0) && isActive)
            {
                isActive = false;
                if (collided)
                {
                    print("Spawn another Pin");
                    SpawnPin(nextPoint);
                    pointSpawner.scorer.score += 100;
                    float newY = 3 + nextPoint.position.y;
                    pointSpawner.MoveCamera(new Vector3(nextPoint.position.x, newY, -10f));
                }
                else
                {
                    pointSpawner.EndGame();
                }
            } 
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Point"))
        {
            collided = true;
            nextPoint = collision.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Point"))
        {
            collided = false;
        }
    }

    void SpawnPin(Transform pointTransform)
    {
        GameObject go = Instantiate(pinPrefab, pointTransform.position, Quaternion.identity, GameObject.Find("Pins").transform);
        go.name = go.name.Replace("(Clone)", "");
        go.GetComponent<PinRotater>().isActive = true;
        go.GetComponent<PinRotater>().speed +=  1;
        go.GetComponent<PinRotater>().pinPrefab = go;
    }
}
