using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D myRB;
    SpriteRenderer myRend;
    Animator Anim;
    bool facingRight = true;
    public float MoveSpeed;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRend = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool isMove = false;

        float lh = Input.GetAxis("Horizontal");
        float lv = Input.GetAxis("Vertical");

        if (lh != 0 || lv != 0) isMove = true;

        if (lh < 0 && !facingRight)
            Flip();
        else if (lh > 0 && facingRight)
            Flip();

        myRB.velocity = new Vector2(lh * MoveSpeed,lv * MoveSpeed);    
        
        
        Anim.SetBool("Move", isMove);
      
    }

    void Flip()
    {
        facingRight = !facingRight;
        myRend.flipX = !myRend.flipX;
    }
}
