using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Move : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed;
    public bool inputLeft=false;
    public bool inputRight=false;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }


    public void LeftDown()
    {
        inputLeft=true;
    }

    public void LeftUp()
    {
        inputLeft=false;
    }

    public void RightDown()
    {
        inputRight=true;
    }

    public void RightUp()
    {
        inputRight=false;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || inputLeft && !inputRight) 
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow) || inputRight && !inputLeft) 
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
    }
}
