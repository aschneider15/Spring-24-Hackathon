using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMove : MonoBehaviour
{
    public GameObject thePlayer;
    public float speed = 4.0f;
    public GameObject gameEndText;
    private bool playerAlive;
    // Start is called before the first frame update
    void Start()
    {
        playerAlive = true;
        this.gameEndText.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAlive = false;
            print("GAME OVER");
            this.thePlayer.SetActive(false);
            this.gameEndText.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.thePlayer.transform.position, this.speed * Time.deltaTime);
    }

   
}
