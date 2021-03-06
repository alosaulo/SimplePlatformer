﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform handCannon;
    public GameObject PlayerProjectilePrefab;

    public bool isOnGround = false;
    public bool canAttack = true;

    [Header("Physics")]
    public float speed;
    public float jumpForce;
    public float gravityForce;

    Rigidbody2D myBody;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Attack();
        Gravity();
    }

    void Movement() {
        float hAxis = Input.GetAxis("Horizontal");

        myAnimator.SetFloat("Walk",Mathf.Abs(hAxis));

        if (hAxis > 0) {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (hAxis < 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        Vector2 newVelocity = new Vector2((myBody.velocity.x + speed) * hAxis * Time.deltaTime,
                                myBody.velocity.y);
        myBody.velocity = newVelocity;
    }

    void Jump(){
        if (Input.GetButtonDown("Jump") && isOnGround) {
            myBody.AddForce(Vector3.up * jumpForce * Input.GetAxis("Jump"));
        }
    }

    void Gravity() {
        if (isOnGround == false) {
            myBody.AddForce(Vector3.down * gravityForce);
        }
    }

    private void Attack() {
        if (Input.GetButton("Fire1") && canAttack == true) {
            StartCoroutine("DoAttack",0.5f);
        }
    }

    IEnumerator DoAttack(float time) {
        canAttack = false;
        myAnimator.SetTrigger("Attack");
        Instantiate(PlayerProjectilePrefab, handCannon.position, handCannon.rotation);
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOnGround == false && 
            collision.gameObject.layer == 8)
        {
            isOnGround = true;
            myAnimator.SetBool("Jump", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (isOnGround == true &&
            collision.gameObject.layer == 8) {
            isOnGround = false;
            myAnimator.SetBool("Jump", true);
        }
    }

}
