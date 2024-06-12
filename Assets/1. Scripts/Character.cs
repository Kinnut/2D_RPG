using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public float strength = 20;
    private float vertical;

    bool isFloor;
    bool isLadder;
    bool isClimbing;
    bool justAttack, justJump;

    private bool faceRight = true;

    public Animator animator;
    private Rigidbody2D rigidbody2d;

    private AudioSource audioSource;
    private AudioClip attackClip;
    private AudioClip jumpClip;

    public float attackSpeed;
    public GameObject attackObj;

    int playerLayer, floorLayer;

    #region Singleton
    public static Character Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = false;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        playerLayer = LayerMask.NameToLayer("Player");
        floorLayer = LayerMask.NameToLayer("Floor");
    }

    private void Update()
    {
        Move();
        JumpCheck();
        AttackCheck();
        ClimbingCheck();

        if (rigidbody2d.velocity.y > 0)
            Physics2D.IgnoreLayerCollision(playerLayer, floorLayer, true);
        else
            Physics2D.IgnoreLayerCollision(playerLayer, floorLayer, false);
    }

    private void FixedUpdate()
    {
        Jump();
        _Attack();
        Climbing();
    }

    void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            justAttack = true;
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (faceRight) Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (!faceRight) Flip();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                justJump = true;
            }
        }
    }

    void _Attack()
    {
        if (justAttack)
        {
            justAttack = false;

            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(attackClip);

            if (gameObject.name == "Bishop(Clone)") // ºñ¼ó
            {
                attackObj.SetActive(true);
                Invoke("SetAttackObjnactive", 1.3f);
            }
            else if (gameObject.name == "DarkNight(Clone)") // ´ÙÅ©³ªÀÌÆ®
            {
                attackObj.SetActive(true);
                Invoke("SetAttackObjnactive", 1.3f);
            }
            else if (gameObject.name == "Marksman(Clone)") // ½Å±Ã
            {
                attackObj.SetActive(true);
                Invoke("SetAttackObjnactive", 1.3f);

                if (faceRight)
                {
                    GameObject obj = Instantiate(attackObj, transform.position, Quaternion.Euler(0, 180, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * attackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3);
                }
                else
                {
                    GameObject obj = Instantiate(attackObj, transform.position, Quaternion.Euler(0, 0, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * attackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3);
                }
            }
        }
    }

    void SetAttackObjnactive()
    {
        attackObj.SetActive(false);
    }

    void Jump()
    {
        if (justJump)
        {
            justJump = false;
            rigidbody2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(jumpClip);
        }
    }

    private void ClimbingCheck()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void Climbing()
    {
        if (isClimbing)
        {
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, vertical * speed);
        }
        else
        {
            rigidbody2d.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
