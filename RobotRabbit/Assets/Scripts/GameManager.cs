using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject robot;

    public InputField txtX;
    public InputField txtY;
    public Dropdown dropdownDirection;
    public Text errorValue;
    

    Rigidbody2D myRB;
    SpriteRenderer myRend;
    Animator Anim;

    bool facingRight = true;

    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite RightSprite;
    public Sprite LeftSprite;

    
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRend = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        errorValue.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place()
    {
        int x = Convert.ToInt32(txtX.text);
        int y = Convert.ToInt32(txtY.text);
        string direction = dropdownDirection.options[dropdownDirection.value].text;

        if (x >= 3 || x <= -3)
            ErrorText();

        if (y >= 3 || y <= -3)
            ErrorText();

        robot.SetActive(true);

        //Change the position
        robot.transform.position = new Vector2(x, y);  
        
        //Change the direction
        switch(direction.ToLower())
        {
            case "north":
                robot.GetComponent<SpriteRenderer>().sprite = UpSprite;
                break;
            case "south":
                robot.GetComponent<SpriteRenderer>().sprite = DownSprite;
                break;
            case "west":
                robot.GetComponent<SpriteRenderer>().sprite = LeftSprite;
                break;
            case "east":
                robot.GetComponent<SpriteRenderer>().sprite = RightSprite;
                break;
        }
       
    }

    void ErrorText()
    {
        errorValue.text = "INVALID VALUE INSERT";
    }

   
    void Flip()
    {
        facingRight = !facingRight;
        myRend.flipX = !myRend.flipX;
    }

}
