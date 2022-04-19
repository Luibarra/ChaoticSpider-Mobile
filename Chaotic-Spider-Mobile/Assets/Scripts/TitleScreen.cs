using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class TitleScreen : MonoBehaviour
{
    public Text Highscore;
    public Transform TitleScreenGroup;
    public Transform OptionsScreenGroup;
    public Transform ShopScreenGroup; 

    void Start()
    {
        TitleScreenGroup.gameObject.SetActive(true); 
        OptionsScreenGroup.gameObject.SetActive(false); 
    }

    void Update()
    {
        Highscore.text = "High Score: " + PlayerPrefs.GetInt("highscore"); 
    }

    public void StartButton()
    {
        SceneManager.LoadScene(0); 
    }

    public void OptionsButton()
    {
        TitleScreenGroup.gameObject.SetActive(false);
        OptionsScreenGroup.gameObject.SetActive(true);
        ShopScreenGroup.gameObject.SetActive(false);
    }

    public void StoreButton()
    {
        TitleScreenGroup.gameObject.SetActive(false);
        OptionsScreenGroup.gameObject.SetActive(false);
        ShopScreenGroup.gameObject.SetActive(true);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }

    public void BackToMenu()
    {
        TitleScreenGroup.gameObject.SetActive(true);
        OptionsScreenGroup.gameObject.SetActive(false);
        ShopScreenGroup.gameObject.SetActive(false);
    }
}
