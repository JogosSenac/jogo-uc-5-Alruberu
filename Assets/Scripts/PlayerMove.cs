using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header ("Movimentação")]
    private float moveInput; 
    public float speed = 2f;
    public int velocidade; 
    public int forcaPulo;
    [Header ("Fisica/Mecanica")]
    private Rigidbody2D rb;
    protected int score = 0;
    

    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        // Captura a entrada horizontal do usuário
        moveInput = Input.GetAxis("Horizontal");

        //JUMP CODE
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            isJumping = true;
        //SE PULAR GANHA PONTO
        score++;
        }
        
    }
    //
    void FixedUpdate()
    {
        // Move o Rigidbody2D com base na entrada horizontal
        Vector2 movement = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    //Codigo que faz a "HitBox" ter ou tomar uma ação quando colidida com outra
    private void OnCollisionEnter2D(Collision2D other)
        //Quando o Player colidir no chão vai comparar a "Tag"
    {
        if(other.gameObject.CompareTag("chao"))
        {
            isJumping = false;
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Morte");
        }
    }

    public int PontosPlayer()
    {
        return score;
    
    }
}

