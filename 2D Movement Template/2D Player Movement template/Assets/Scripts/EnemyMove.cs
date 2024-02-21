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

    private int spriteVersion = 0;
    public Sprite[] sprites;
    private SpriteRenderer sr;
    public int animSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(changeSprite), this.animSpeed, this.animSpeed);
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

    void changeSprite() {
        if(spriteVersion == 0) {
            spriteVersion = 1;
        } else if(spriteVersion == 1) {
            spriteVersion = 0;
        }
        sr.sprite = sprites[spriteVersion];
    }

   
}
