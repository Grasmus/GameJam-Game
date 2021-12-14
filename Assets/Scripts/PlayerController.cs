using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public int Health;

    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public GameObject[] bar;
    public GameObject[] enemy;
    public GameObject weapon;
    public GameObject endGame;
    public AudioClip attemp;
    public bool ActivateOnStart = true;
    public float ActivationDelay = 0.01f;
    public float AttackDelay = 0.01f;
    private bool isAttack = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Health >= 100)
        {
            bar[0].SetActive(true);
            bar[1].SetActive(false);
            bar[2].SetActive(false);
            bar[3].SetActive(false);
            bar[4].SetActive(false);
            bar[5].SetActive(false);
            bar[6].SetActive(false);
        }
        else if (Health < 100 && Health > 80)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(true);
            bar[2].SetActive(false);
            bar[3].SetActive(false);
            bar[4].SetActive(false);
            bar[5].SetActive(false);
            bar[6].SetActive(false);
        }
        else if (Health < 80 && Health > 60)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(false);
            bar[2].SetActive(true);
            bar[3].SetActive(false);
            bar[4].SetActive(false);
            bar[5].SetActive(false);
            bar[6].SetActive(false);
        }
        else if (Health < 60 && Health > 40)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(false);
            bar[2].SetActive(false);
            bar[3].SetActive(true);
            bar[4].SetActive(false);
            bar[5].SetActive(false);
            bar[6].SetActive(false);
        }
        else if (Health < 40 && Health > 20)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(false);
            bar[2].SetActive(false);
            bar[3].SetActive(false);
            bar[4].SetActive(true);
            bar[5].SetActive(false);
            bar[6].SetActive(false);
        }
        else if (Health < 20 && Health > 1)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(false);
            bar[2].SetActive(false);
            bar[3].SetActive(false);
            bar[4].SetActive(false);
            bar[5].SetActive(true);
            bar[6].SetActive(false);
        }
        else if (Health < 1)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(false);
            bar[2].SetActive(false);
            bar[3].SetActive(false);
            bar[4].SetActive(false);
            bar[5].SetActive(false);
            bar[6].SetActive(true);
        }

        if (isAttack == false)
        {
            ActivateDelayeAttackd();
            if (Input.GetMouseButtonDown(0))
            {
                isAttack = true;

                Debug.Log("Damage");
                animator.SetBool("IsAttack", true);
                animator.SetBool("IsWalk", false);
                weapon.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(attemp);
            }
            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("IsAttack", false);
                animator.SetBool("IsWalk", false);
                weapon.SetActive(false);
            }
        }

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("IsWalk", true);
        }
        else { animator.SetBool("IsWalk", false); }

        moveVelocity = moveInput.normalized * Speed;

        if (Health <= 0)
        {
            endGame.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sr.flipX = true;
            //rb.MoveRotation(180);
            // playerBody.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sr.flipX = false;
        }

        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    public void DamagePlayer(int damage)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        ActivateDelayed();
        Health -= damage;
    }

    private void AfterDelay()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void ActivateDelayed()
    {
        Invoke(nameof(AfterDelay), ActivationDelay);
    }

    public void AttackDelayed(float customDelay)
    {
        Invoke(nameof(AfterDelayAttack), customDelay);
    }



    private void AfterDelayAttack()
    {
        isAttack = false;
    }

    public void ActivateDelayeAttackd()
    {
        Invoke(nameof(AfterDelayAttack), AttackDelay);
    }

    public void ActivateDelayed(float customDelay)
    {
        Invoke(nameof(AfterDelay), customDelay);
    }



}
