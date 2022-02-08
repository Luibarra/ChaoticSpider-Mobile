using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EscapeTrigger : MonoBehaviour
{
    GameManager GM;
    void Start()
    {
        GM = GameObject.FindObjectOfType<Canvas>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("points", GM.points);

            if (GM.points > GM.highscore)
            {
                GM.highscore = GM.points;
                PlayerPrefs.SetInt("highscore", GM.highscore);
            }

            SceneManager.LoadScene(2); 
        }
    }
}
