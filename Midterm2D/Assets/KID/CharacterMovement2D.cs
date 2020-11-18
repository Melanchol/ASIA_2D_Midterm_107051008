using UnityEngine;

namespace KID
{
    public class CharacterMovement2D : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 1;
    [Header("地板判定位置")]
    public Vector3 groundPoint;
    [Header("地板判定長度"), Range(0f, 1f)]
    public float groundLength = 0.1f;
    [Header("跳躍高度"), Range(0f, 2000f)]
    public float jump = 500f;
    [Header("動畫參數：跑步")]
    public string parRun = "跑步開關";
    [Header("動畫參數：跳躍")]
    public string parJump = "跳躍觸發";
    [Header("動畫參數：死亡")]
    public string parDead = "死亡開關";
        [Header("攻擊1")]
        public string parAtk1 = "攻擊1";
        [Header("攻擊2")]
        public string parAtk2 = "攻擊2";

        private Rigidbody2D rig;
    private Animator ani;
    private bool isGround;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        FloorCheck();
        Jump();
            Atk();
        }

    private void FixedUpdate()
    {
        Move();
    }

    private void FloorCheck()
    {
        if (!isGround && Physics2D.Raycast(transform.position + groundPoint, -transform.up, groundLength, 1 << 8)) isGround = true;
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.anyKey)
        {
            rig.AddForce(Vector3.right * h * Time.fixedDeltaTime * speed);

            if (h == 1) transform.eulerAngles = Vector3.zero;
            else if (h == -1) transform.eulerAngles = new Vector3(0, 180, 0);
        }

        ani.SetBool(parRun, h != 0);
    }

    private void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.W))
        {
            isGround = false;
            rig.AddForce(Vector3.up * jump);
            ani.SetTrigger(parJump);
        }
    }
        private void Atk()
        {
            if (isGround && Input.GetKeyDown(KeyCode.Z))
            {
                print("atk1");
                ani.SetTrigger(parAtk1);
            }
            if (isGround && Input.GetKeyDown(KeyCode.X))
            {
                print("atk2");
                ani.SetTrigger(parAtk2);
            }
        }
        

        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + groundPoint, -transform.up * groundLength);
    }
}
}
