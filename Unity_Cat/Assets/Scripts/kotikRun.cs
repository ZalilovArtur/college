using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kotikRun : MonoBehaviour
{
    public Vector2 speedKot = new Vector2(10, 10);
    private bool isRunLeft = true;
    public float inputX;
    public bool flag;
    private Animator anim;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(inputX));
        anim.SetBool("jump", false);
        movement = new Vector2(inputX * speedKot.x, 0);
        GetComponent<Rigidbody2D>().velocity = movement;
        if (inputX < 0 && isRunLeft)
        {
            Flip();
        }
        else if(inputX > 0 && !isRunLeft)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space) && flag)
        {
            Jump();
        }
    }

    private void Flip()
    {
        isRunLeft = !isRunLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7000));
        anim.SetBool("jump", true);
        flag = false;
    }

    void OnCollisionEnter2D(Collision2D Stolknovenie)
    {
        if (Stolknovenie.collider == true)
        {
            flag = true;
        }
    }
}
