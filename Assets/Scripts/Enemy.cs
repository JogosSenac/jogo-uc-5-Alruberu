using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class moveEnemy: MonoBehaviour
{
    [Header ("Movimento")]
    public float BaseSpeed;
    public float speedMultiplier = 0.1f; //Velocidade baseado na pontuação
    private float moveInput;
    public Rigidbody2D enemyRb;
    private bool faceFlip; //SE COLIDIR COM OBJ MUDA DE DIREÇÃO
    public PlayerMove scorePlayer;

    private void Start() 
    {
        scorePlayer = GameObject.FindObjectOfType<PlayerMove>();
    }
    
  
    void Update()
    {
        BaseSpeed = speedMultiplier * scorePlayer.PontosPlayer();
        transform.Translate(Vector2.left * BaseSpeed * Time.deltaTime);
        
    }
    private void FlipEnemy()
    {
        if (faceFlip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D col) //Detectação de colisor
    {//PPRA NÂO VIRAR QUANDO COLIDIR OM PLAYER E CHAO
        if(col != null && !col.collider.CompareTag("Player") && !col.collider.CompareTag("chao"))
        {
            faceFlip = !faceFlip;
        }

        FlipEnemy();

    }

    
}