using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Velocity : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;

    private Rigidbody Player;
    [Header("�򥻰Ѽ�")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float MaxSpeed;
    [SerializeField]
    private float rayLength;
    private bool jumpKey;
    private bool LeftShitftKey;
    [SerializeField]
    private float jumpForce;
    [Header("�ʵe�Ѽ�")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float StopMoveRange;
    private bool OnMove;
    private float MoveSpeedx;
    private float MoveSpeedz;

    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }
    void Update()
    {
        playerInput();
        speedLimiter();
        AnimatorControl();
    }
    private void FixedUpdate()
    {
        junpCheck();
        movement();
        rotate();
    }
    private void playerInput()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("���a���U�F���D���s");
            jump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("���a���ULeft Shift");
            LeftShitftKey = true;
            animator.SetBool("LeftShitf", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("���a��} Left Shitf");
            LeftShitftKey = false;
            animator.SetBool("LeftShitf", false);

        }
    }
    private void AnimatorControl()
    {
        MoveSpeedx = Player.velocity.x;
        MoveSpeedz = Player.velocity.z;
        animator.SetFloat("MoveSpeedx", MoveSpeedx);
        animator.SetFloat("MoveSpeedz", MoveSpeedz);

        if(Player.velocity.x < -StopMoveRange || Player.velocity.x > StopMoveRange)
            OnMove = true;
        else OnMove = false;

        if (Player.velocity.z < -StopMoveRange || Player.velocity.z > StopMoveRange)
            OnMove = true;
        else OnMove = false;

        animator.SetBool("OnMove", OnMove);

    }
    private void movement()
    {
        if(LeftShitftKey)
        {
            Run();
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        /*
        Vector3 forward = Camera.main.transform.forward.normalized;
        Vector3 right = Camera.main.transform.right.normalized;
        */
        Vector3 forward = new Vector3(Camera.main.transform.forward.x,0, Camera.main.transform.forward.z).normalized;
        Vector3 right = new Vector3(Camera.main.transform.right.x,0, Camera.main.transform.right.z).normalized;

        Player.velocity += new Vector3(right.x, 0, right.z) * Horizontal * speed;
        Player.velocity += new Vector3(forward.x, 0, forward.z) * Vertical * speed;
       // Debug.DrawLine(Player.transform.position, new Vector3(forward.x,0,forward.z), Color.red);
        
    }
    private void Run()
    {
        Vector3 forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 right = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        Player.velocity += new Vector3(right.x, 0, right.z) * Horizontal * runSpeed;
        Player.velocity += new Vector3(forward.x, 0, forward.z) * Vertical * runSpeed;
    }

    private void speedLimiter()
    {
        //x
        if (Player.velocity.x > MaxSpeed)
        {
            Player.velocity = new Vector3(MaxSpeed, Player.velocity.y, Player.velocity.z);
        }
        if (Player.velocity.x < -MaxSpeed)
        {
            Player.velocity = new Vector3(-MaxSpeed, Player.velocity.y, Player.velocity.z);
        }

        //z
        if (Player.velocity.z > MaxSpeed)
        {
            Player.velocity = new Vector3(Player.velocity.x, Player.velocity.y, MaxSpeed);
        }
        if (Player.velocity.z < -MaxSpeed)
        {
            Player.velocity = new Vector3(Player.velocity.x, Player.velocity.y, -MaxSpeed);
        }
    }

    private void rotate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        Vector3 directionForward = new Vector3(cameraForward.x, 0, cameraForward.z);
        Vector3 directionRight = new Vector3(cameraRight.x, 0, cameraRight.z);

        Vector3 Direction = directionForward * Vertical + directionRight * Horizontal;
        Quaternion quaternion = Quaternion.LookRotation(Direction);

        if (Horizontal != 0 || Vertical != 0)
        {
            this.transform.rotation = quaternion;
            Debug.Log("�ഫ��");
        }
        Debug.DrawRay(this.transform.position, cameraForward * Vertical, Color.blue);
        Debug.DrawRay(this.transform.position, cameraRight * Horizontal, Color.blue);
    }
    private void jump()
    {
        if (jumpKey)
        {
            float y = jumpForce;

            Player.AddForce(0, y, 0, ForceMode.Impulse);
            Debug.Log("���D");
            animator.SetTrigger("Jump");
        }
        else Debug.Log("�L�k���D");
    }
    public void animationJump()
    {
        float y = jumpForce;
        Player.AddForce(0, y, 0, ForceMode.Impulse);
    }
    private void junpCheck()
    {
        Vector3 direction = new Vector3(0, -rayLength, 0);
        Ray ray = new Ray(this.transform.position, direction);

        LayerMask mask = LayerMask.GetMask("surrounding");

        if (Physics.Raycast(ray, rayLength, mask))
        {
            jumpKey = true;
        }
        else jumpKey = false;
    }
    private void OnDrawGizmos()
    {
        Vector3 direction = new Vector3(0, -rayLength, 0);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, direction);
    }
}
