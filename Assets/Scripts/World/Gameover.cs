using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    float finalScore;
    public Text enemiesDestroyedText;
    public Text objectsDestroyedText;
    public Text coinsText;
    public Text scoreText;
    public Text finalScoreText;
    // Start is called before the first frame update
    
    public void CalculateScore(int enemiesDestroyed,int objectsDestroyed,int coinsPickedUp,int score)
    {
        finalScore = (enemiesDestroyed/10 )+ (objectsDestroyed/10) + (coinsPickedUp/10) + (score/100);
        GameManager.Instance.economicManager.coinVioletCounter += (int)finalScore;
        DisplayScore(enemiesDestroyed,objectsDestroyed,coinsPickedUp,score);
    }
    void DisplayScore(int enemiesDestroyed,int objectsDestroyed,int coinsPickedUp,int score)
    {
        enemiesDestroyedText.text = enemiesDestroyedText.text + enemiesDestroyed.ToString();
        objectsDestroyedText.text = objectsDestroyedText.text + objectsDestroyed.ToString();
        coinsText.text = coinsText.text + coinsPickedUp.ToString();
        scoreText.text = scoreText.text + score.ToString();
        finalScoreText.text = finalScoreText.text + finalScore.ToString();
    }
}
