using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSpawner : MonoBehaviour {

    public Camera cameraObject;
    public Text GameOver_Txt;
    public GameObject pointPrefab;
    public ParticleSystem particlePoint;
    public bool isRoundActive = true;
    [HideInInspector] public Scorer scorer;
    private Transform lastPoint;

    void Start () {

        scorer = FindObjectOfType<Scorer>();

        lastPoint = GameObject.Find("Point").transform;
        isRoundActive = true;

        for (int i = 0; i < 20; i++)
        {
            SpawnPoint();
        }
	}

    private void Update()
    {
        if (!isRoundActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void EndGame()
    {
        print("End Game");
        isRoundActive = false;
        GameOver_Txt.gameObject.SetActive(true);
    }
    
    public void SpawnPoint()
    {
        GameObject go = Instantiate(pointPrefab, RandomCircle(lastPoint.position, 0.9f, Random.Range(-60f, 60f)), Quaternion.identity, GameObject.Find("Points").transform);
        lastPoint = go.transform;
    }

    public void MoveCamera(Vector3 newPosition)
    {
        cameraObject.transform.position = newPosition;
    }

    Vector3 RandomCircle(Vector3 center, float radius, float a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

}
