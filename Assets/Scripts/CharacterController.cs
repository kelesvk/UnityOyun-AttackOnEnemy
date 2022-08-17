using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    public int damage;

    float moveInput;

    Animator animator;
    Rigidbody2D rb;
    bool canJump = true;
    bool faceRight = true;
    bool canAttack=true;
    Vector2 forward;

    public Vector3 offset;

    RaycastHit2D hit;

    private void Start()
    {

        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {


        moveInput = Input.GetAxis("Horizontal"); // BİLGİSAYAR MODU

        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);

        if(moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    
        if(faceRight == true && moveInput<0)
        {
            Flip();

        }
        else if(faceRight== false && moveInput>0)
        {
            Flip();
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.F) && canAttack)
        {
            Attack();
        }

    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Platform"){
            canJump=true;
        }
    }

    public void MoveRight()
    {
       moveInput=1;
    }
    public void MoveLeft()
    {
        moveInput=-1;
    }
    public void StopMovement()
    {
        moveInput=0;
    }


    public void Jump(){
        if (canJump){
            rb.AddForce(Vector2.up * jumpSpeed);
            canJump=false;
        }
    }
    private void Flip(){
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale=scaler;
    }

    private void Attack()
    {
        canAttack=false;

        if(!faceRight)
        {
            forward=transform.TransformDirection(Vector2.right * -2);
        }
        else
        {
            forward=transform.TransformDirection(Vector2.right * 2);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position+offset, forward, 1.0f);

    if(hit)
    {
        if(hit.transform.tag == "Enemy")
        {
            hit.transform.GetComponent<SimpleEnemyBehaviour>().TakeDamage(damage);
        }
        else
        {
            Debug.Log("nothing to hit");
        }
    }

    animator.SetTrigger("attack");
    StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        canAttack=true;
    }


}
