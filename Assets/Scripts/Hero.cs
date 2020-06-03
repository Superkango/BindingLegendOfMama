using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hero : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D myRigidbody;
    private Vector3 move;
    private Animator animator;
    public Text scoreText;
    private int score = 0;
    public Text highScoreText;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Vector3.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        UpdateAnimation();

        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Attack");
        }

    }

    //void Attack()
    //{
       
    //}

    void UpdateAnimation()
    {
        if(move != Vector3.zero)
        {
               MoveCharacter();
               animator.SetFloat("MoveX", move.x);
               animator.SetFloat("MoveY", move.y);
               animator.SetBool("Walking", true);             
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + move * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.GetInt("High Score") < score)
        {
            PlayerPrefs.SetInt("High Score", score);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        scoreText.text = "" + score;
    }
}
