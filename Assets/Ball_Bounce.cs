using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Bounce : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float bounce_power;
    public float jump_power;
    int gameover_count=2;
    // GoogleAdMobScript ad = new GoogleAdMobScript();
    int direction; // 물체의  y 방향을 숫자 1, -1로 기록

    public bool inputJump=false;
    protected int canjump;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.transform.position=new Vector2(0, -2);
        canjump=1;
    }


    public void JumpDown()
    {
        inputJump=true;
    }

    public void JumpUp()
    {
        inputJump=false;
    }
    void Update()
    {
        if(rb.velocity.normalized.y>0)  direction=1;
        else if(rb.velocity.normalized.y==0) direction=0;
        else direction=-1;

        if((Input.GetKeyDown(KeyCode.Space) || inputJump) && canjump==1) 
        {
            rb.velocity=Vector2.up*jump_power;
            canjump=0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        canjump=1;
        if(other.gameObject.name=="Ground" || other.gameObject.name=="Stick")
        {
            if(direction==-1 || direction==0) rb.velocity=Vector2.up*bounce_power;
            else rb.velocity=(-1)*Vector2.up;
        }
        
        else if(other.gameObject.name=="Camera")
        {
        SceneManager.LoadScene("GameOver");
        gameover_count++;
        if (gameover_count>=3)
        {
            gameover_count=0;
            // ad.AdStart();
        }
        }

        else if(other.gameObject.name=="Flag")
        {
        SceneManager.LoadScene("GameSuccess");
        // ad.AdStart();
        }
    }

}
