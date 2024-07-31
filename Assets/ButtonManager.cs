using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Ball_Bounce ball_jump;
    public Ball_Move ball;

    /*
    GameObject balls;


    public void Init()
    {
        balls=GameObject.FindGameObjectWithTag("ball");
        ball_jump=balls.GetComponent<Ball_Bounce>;
    }
    */

    public void LeftDown()
    {
        ball.inputLeft=true;
    }

    public void LeftUp()
    {
        ball.inputLeft=false;
    }

    public void RightDown()
    {
        ball.inputRight=true;
    }

    public void RightUp()
    {
        ball.inputRight=false;
    }

    public void JumpDown()
    {
        ball_jump.inputJump=true;
    }

    public void JumpUp()
    {
        ball_jump.inputJump=false;
    }
}
