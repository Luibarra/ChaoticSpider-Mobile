using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public int points = 0;
    public int stompForce = 10;
    public float range;
    public bool deadSpyder = false;
    public int highscore = 0; 

    private int callCount = 0;
    private bool paused = false;

    Transform CanvasPlayGroup;
    Transform CanvasPauseGroup;

    public Text score;
    public Text Highscore;
    public Text scoreReport;

    public GameObject BOOT;
    public GameObject SPYDER;

    public Camera DeathCam;
    public Camera PlayCam;

    void Start()
    {
        Time.timeScale = 1;
        DeathCam.enabled = false;
        PlayCam.enabled = true; 
        InvokeRepeating("DropDaBOOT", 0f, 4f);

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        Highscore.text = "Highscore: " + highscore;

        CanvasPlayGroup = GameObject.FindObjectOfType<Canvas>().transform.GetChild(0);
        CanvasPauseGroup = GameObject.FindObjectOfType<Canvas>().transform.GetChild(2);
    }

    void Update()
    {
        score.text = "Objects Tossed: " + points;
        scoreReport.text = "Objects Tossed: " + points;

        if(Input.GetButtonDown("Submit"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true; 

                CanvasPauseGroup.gameObject.SetActive(true); 
                CanvasPlayGroup.gameObject.SetActive(false); 
            }
            else
            {
                Time.timeScale = 1;
                paused = false;

                CanvasPauseGroup.gameObject.SetActive(false);
                CanvasPlayGroup.gameObject.SetActive(true);
            }
        }

        switch (callCount)
        {
            case 3:
                CancelInvoke(); 
                InvokeRepeating("DropDaBOOT", 0f, 3f);
                break;
            case 6:
                CancelInvoke();
                InvokeRepeating("DropDaBOOT", 0f, 2f);
                break;
            case 10:
                CancelInvoke();
                InvokeRepeating("DropDaBOOT", 0f, 1.5f);
                break;
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0); 
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    public void DropDaBOOT()
    {
        if(!deadSpyder)
        {
            callCount++;
            Instantiate(BOOT, new Vector3(SPYDER.transform.position.x, SPYDER.transform.position.y * range, SPYDER.transform.position.z), Quaternion.identity);
            StartCoroutine(deleteTimer());
            Destroy(GameObject.FindGameObjectWithTag("Boot"));
        }
    }

    IEnumerator deleteTimer()
    {
        yield return new WaitForSeconds(1);
    }
}
