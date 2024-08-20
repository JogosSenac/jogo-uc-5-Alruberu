using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int velocidade;
    public int forcaPulo;
    private Rigidbody2D rb;
    protected int Score = 0;

    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        //JUMP CODE
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            isJumping = true;
        }
        //POINT MOVE CODE

    }

    //Codigo que faz a "HitBox" ter ou tomar uma ação quando colidida com outra
    private void OnCollisionEnter2D(Collision2D other)
        //Quando o Player colidir no chão vai comparar a "Tag"
    {
        if(other.gameObject.CompareTag("Chão"))
        {
            isJumping = false;
        }
    }
}
