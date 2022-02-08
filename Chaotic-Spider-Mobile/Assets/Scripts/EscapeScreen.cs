using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeScreen : MonoBehaviour
{
    public Text score;
    public Text highscore; 
    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        score.text = "Objects Tossed: " + PlayerPrefs.GetInt("points"); 
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
