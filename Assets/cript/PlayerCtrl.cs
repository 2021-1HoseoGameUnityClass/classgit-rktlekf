using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 4f;
    private float jumpPower = 6f;
    private int maxJump = 1;
    private int jumpCount = 0;

    private float shotTime = 0f;
    private float shotDelayTime = 0.5f;

    private bool isPlatform;

    public Transform shotPos;
    public Transform checkPos;

    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    AudioSource myAudio;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        myAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Jump();
        Shot();

        if (rigid.velocity.y < 0)
        {
           //anim.SetBool("isFall", true);
        }
    }

    private void FixedUpdate()
    {
        Move();
        //CheckPlatform();
    }

    #region ������
    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(inputX * moveSpeed * Time.deltaTime, 0));

        if (inputX > 0)
        {
            sprite.flipX = false;
            anim.SetBool("isWalk", true);
        }
        else if (inputX < 0)
        {
            sprite.flipX = true;
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void Jump()
    {
        //if (Input.GetButtonDown("Jump") && jumpCount < maxJump)
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump"))
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isJump", true);
            //anim.SetBool("isFall", false);

            rigid.velocity = Vector2.up * jumpPower;

            jumpCount++;
        }
    }
    #endregion

    private void Shot()
    {
        if (shotTime >= shotDelayTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shotTime = 0f;

                float direction = 0;

                if (sprite.flipX)
                {
                    direction = -1; //����
                }
                else
                {
                    direction = 1; //������
                }

                myAudio.Play();

                GameObject bulletPrefab = Instantiate(Resources.Load<GameObject>("Bullet"), shotPos.position, Quaternion.identity);
                bulletPrefab.GetComponent<Bullet>().direction = direction;
            }
        }
        else
        {
            shotTime += Time.deltaTime;
        }
    }

    private void CheckPlatform()
    {
        isPlatform = Physics2D.OverlapCircle(checkPos.transform.position, 0.05f, LayerMask.GetMask("Platform"));

        if (isPlatform)
        {
            //jumpCount = 0;

            anim.SetBool("isJump", false);
            //anim.SetBool("isFall", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            isPlatform = false;
            anim.SetBool("isJump", false);
        }
    }
}