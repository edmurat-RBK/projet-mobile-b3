using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    float finalScore;
    // public Text enemiesDestroyedText;
    // public Text objectsDestroyedText;
    // public Text coinsText;
    // public Text scoreText;
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
        // enemiesDestroyedText.text = enemiesDestroyedText.text + enemiesDestroyed.ToString();
        // objectsDestroyedText.text = objectsDestroyedText.text + objectsDestroyed.ToString();
        // coinsText.text = coinsText.text + coinsPickedUp.ToString();
        // scoreText.text = scoreText.text + score.ToString();
        finalScoreText.text = finalScore.ToString();
    }
    public void Revive()
    {
        if(GameManager.Instance.economicManager.coinVioletCounter >= GameManager.Instance.economicManager.revivePrice)
        {
            GameManager.Instance.playerManager.revive = true;
            StartCoroutine(GameManager.Instance.playerManager.player.GetComponent<PlayerLife>().PlayerDeath());
            gameObject.SetActive(false);

            GameManager.Instance.economicManager.coinVioletCounter -= GameManager.Instance.economicManager.revivePrice;
        }
        else
        {
            AudioManager.AMInstance.UIImpossibleAudio.Post(gameObject);
        }

        
    }


    public void QuitMenu()
    {
        Time.timeScale = 1f;
        
        AudioManager.AMInstance.UIReturnMenuAudio.Post(gameObject);
        AudioManager.AMInstance.StopAllAudio();
        Destroy(AudioManager.AMInstance.gameObject);
        AudioManager.AMInstance = null;
        
        DataManager.DMInstance.Save(FindObjectOfType<UIDisplay>().displayedScore,GameManager.Instance.economicManager.coinCounter,GameManager.Instance.economicManager.coinVioletCounter);
        SceneManager.LoadScene("Menu Start");
    }
}
