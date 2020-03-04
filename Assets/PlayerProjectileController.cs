using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{

    public float Speed;

    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        if(transform.position.y == 0)
            myBody.AddRelativeForce(Vector2.right * Speed);
        if (transform.position.y == 180)
            myBody.AddRelativeForce(Vector2.left * Speed);

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
