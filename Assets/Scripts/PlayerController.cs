using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D myBody;
    Animator myAnimator;

    public bool isOnGround = false;
    [Header("Physics")]
    public float speed;
    public float jumpForce;
    public float gravityForce;
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

    private void OnTriggerEnter2D(Collider2D collision){
        if (isOnGround == false) {
            isOnGround = true;
            myAnimator.SetBool("Jump", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (isOnGround == true) {
            isOnGround = false;
            myAnimator.SetBool("Jump", true);
        }
    }

}
