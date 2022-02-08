using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootDeath : MonoBehaviour
{
    GameManager GM;
    Transform CanvasDeathGroup;
    Transform CanvasPlayGroup; 
    Transform CanvasPauseGroup; 
    void Start()
    {
        GM = GameObject.FindObjectOfType<Canvas>().GetComponent<GameManager>();

        CanvasPlayGroup = GameObject.FindObjectOfType<Canvas>().transform.GetChild(0);
        CanvasDeathGroup = GameObject.FindObjectOfType<Canvas>().transform.GetChild(1);

        CanvasDeathGroup.gameObject.SetActive(false); 
        CanvasPlayGroup.gameObject.SetActive(true); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GM.PlayCam.enabled = false;
            GM.DeathCam.enabled = true;
            GM.deadSpyder = true; 

            Destroy(collision.gameObject);

            CanvasDeathGroup.gameObject.SetActive(true);
            CanvasPlayGroup.gameObject.SetActive(false);
        }
    }
}
