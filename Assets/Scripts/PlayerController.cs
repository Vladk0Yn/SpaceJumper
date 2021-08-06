using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Text;
    public GameObject TextRecord;
    private TextMeshProUGUI score;
    private TextMeshProUGUI Record;
    private int count = -1;
    private int recordValue;
    public Joystick joystick;
    public float speed;
    public float jumpSpeed;
    private float move;
    Rigidbody2D rb;
    readonly Vector2 force = new Vector2(0, 600);
    bool inAir = false;
    private Animator anim;
    private SpriteRenderer sprite;
    private string path;
    
    private void Start()
    {
        path = Application.persistentDataPath + "/Record.data";
        if (File.Exists(path))
        {
            StreamReader input = new StreamReader(path);
            recordValue = Int32.Parse(input.ReadLine());
        }
        score = Text.GetComponent<TextMeshProUGUI>();
        Record = TextRecord.GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 300;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        if (!inAir)
        {
            anim.SetBool("isJump",false);
            move = joystick.Horizontal;
            if (move < 0)
            {
                sprite.flipX = true;
                rb.velocity = new Vector2(speed*move, rb.velocity.y);
            }
            else if (move > 0)
            {
                sprite.flipX = false;
                rb.velocity = new Vector2(speed*move, rb.velocity.y);
            }
            if (joystick.Horizontal != 0)
            {
                anim.SetBool("isRun", true);
                anim.SetBool("isWait", false);
            }
            else
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isWait", true);
            }
            
        }
        else if (inAir)
        {
            move = joystick.Horizontal;
            if (move < 0)
            {
                sprite.flipX = true;
                rb.velocity = new Vector2(jumpSpeed*move, rb.velocity.y);
            }
            else if (move > 0)
            {
                sprite.flipX = false;
                rb.velocity = new Vector2(jumpSpeed*move, rb.velocity.y);
            }

            else if (move == 0)
            {
                rb.velocity = new Vector2(jumpSpeed * 0.5f, rb.velocity.y);
            }
        }
        if (rb.position.y < -12)
        {
            if (count > recordValue)
            {
                recordValue = count;
                StreamWriter output = new StreamWriter(path);
                output.WriteLine(Convert.ToString(recordValue));
                output.Close();
            }
            SceneManager.LoadScene("menu");
        }
        score.text = Convert.ToString(count);
        Record.text = "Ваш рекорд " + Convert.ToString(count > recordValue ? count: recordValue);
    }

    public void OnJumpButtonDown()
    {
        if (!inAir)
         {
             inAir = true;
             rb.AddForce(force);
             if(jumpSpeed<13)
                jumpSpeed += 0.1f;
         }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isWait",true);
            this.transform.parent = collision.transform; 
            inAir = false;
            count++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            this.transform.parent = null;
            anim.SetBool("isJump", true);
            anim.SetBool("isWait",false);
            anim.SetBool("isRun", false);
        }
    }
}
