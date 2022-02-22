using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameManager GM;
    public Transform player; 
    void Start()
    {
        GM = GameObject.FindObjectOfType<Canvas>().GetComponent<GameManager>();
    }

    void Update()
    {
        if (!GM.deadSpyder)
        {
            transform.position = new Vector3(player.position.x, player.position.y + 5, player.position.z);
        }
    }
}
