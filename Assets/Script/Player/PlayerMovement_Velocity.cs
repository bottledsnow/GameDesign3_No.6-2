using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Velocity : MonoBehaviour
{
    [Header("監控")]
    [SerializeField]
    private Vector3 PlayerVelocity;
    [SerializeField]
    private Vector3 forward;
    [SerializeField]
    private Vector3 right;
    private float Horizontal;
    private float Vertical;

    private Rigidbody Player;
    [Header("基本參數")]
    [SerializeField]
    private float MoveDrag;
    [SerializeField]
    private float AngleDifference;
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
    [Header("動畫參數")]
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
        PlayerVelocity = Player.velocity;
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
            Debug.Log("玩家按下了跳躍按鈕");
            jump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("玩家按下Left Shift");
            LeftShitftKey = true;
            animator.SetBool("LeftShitf", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("玩家放開 Left Shitf");
            LeftShitftKey = false;
            animator.SetBool("LeftShitf", false);

        }
    }
    private void AnimatorControl()
    {
        MoveSpeedx = Player.velocity.x;
        MoveSpeedz = Player.velocity.z;
        animator.SetFloat("MoveSpeedx", MoveSpeedx);
        //animator.SetFloat("MoveSpeedz", MoveSpeedz);

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

        if (jumpKey) Player.drag = MoveDrag;
        else Player.drag = 0;
        Vector3 forward = new Vector3(Camera.main.transform.forward.x,0, Camera.main.transform.forward.z).normalized;
        Vector3 right = new Vector3(Camera.main.transform.right.x,0, Camera.main.transform.right.z).normalized;

        Player.velocity += new Vector3(forward.x, 0, forward.z) * Vertical * speed;
        float angleDifference = Player.transform.rotation.eulerAngles.y - Camera.main.transform.rotation.eulerAngles.y;
        if (Mathf.Abs(angleDifference) > AngleDifference)
        {
            Player.velocity += new Vector3(right.x, 0, right.z) * Horizontal * speed;
        }
        
        

        
    }
    private void Run()
    {
        if (jumpKey) Player.drag = MoveDrag;
        else Player.drag = 0;
        Vector3 forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 right = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        Player.velocity += new Vector3(forward.x, 0, forward.z) * Vertical * runSpeed;
        float angleDifference = Player.transform.rotation.eulerAngles.y - Camera.main.transform.rotation.eulerAngles.y;
        if (Mathf.Abs(angleDifference) > AngleDifference)
        {
            Player.velocity += new Vector3(right.x, 0, right.z) * Horizontal * runSpeed;
        }
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

        if (Horizontal != 0 || Vertical != 0 )
        {
            this.transform.rotation = quaternion;
            Debug.Log("轉換中");
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
            Debug.Log("跳躍");
            animator.SetTrigger("Jump");
        }
        else Debug.Log("無法跳躍");
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
        LayerMask maskR = LayerMask.GetMask("Color_Red");
        LayerMask maskB = LayerMask.GetMask("Color_Blue");
        LayerMask maskG = LayerMask.GetMask("Color_Green");

        if (Physics.Raycast(ray, rayLength, mask))
        {
            jumpKey = true;
        } 
        else
        if (Physics.Raycast(ray, rayLength, maskR)) 
        {
            jumpKey = true;
        }
        else
        if (Physics.Raycast(ray, rayLength, maskB))
        {
            jumpKey = true;
        }
        else
        if (Physics.Raycast(ray, rayLength, maskG))
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
