using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    GameManager GM; 
    void Start()
    {
        GM = GameObject.FindObjectOfType<Canvas>().GetComponent<GameManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Points")
        {
            GM.points++;
            other.tag = "Ground"; 
        }
    }
}
