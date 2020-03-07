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
        Debug.Log(transform.rotation.y);
        if(transform.rotation.y == 0)
            myBody.AddRelativeForce(Vector2.right * Speed);
        if (transform.rotation.y == -1 ||
            transform.rotation.y == 1)
            myBody.AddRelativeForce(Vector2.left * Speed);

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
