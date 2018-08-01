using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour {

    public float score;
    private Text score_txt;
    PointSpawner pointSpawner;

    private void Start()
    {
        score = 0f;
        score_txt = GetComponent<Text>();
        pointSpawner = FindObjectOfType<PointSpawner>();
    }

    private void Update()
    {
        if (pointSpawner.isRoundActive)
        {
            if (score < 0)
                score = 0;
            score_txt.text = "Score : " + Mathf.Round(score);
        }
    }

}
