using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    
    public Text highScoreText;
    float highScore;
    public int displayedScore;
    [HideInInspector]
    public float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        displayedScore = (int)highScore; 

        highScoreText.text = displayedScore.ToString(); 

        highScore = highScore + (GameManager.Instance.terrainManager.scrollSpeed / GameManager.Instance.terrainManager.baseScrollspeed) * Time.deltaTime * multiplier;
    }
}
