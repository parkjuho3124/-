using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동 관련")]
    private float moveInput;
    private bool isGrounded;
    private bool jumpPressed;

    [Header("지면 체크")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("연결 컴포넌트")]
    private Rigidbody2D rb;
    private Animator anim;

    [Header("플레이어 스탯")]
    public PlayerStats stats; //  연결: PlayerStats.cs

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 좌우 이동 입력
        moveInput = Input.GetAxisRaw("Horizontal");

        // 스프라이트 방향 전환
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;
        }

        // 지면 체크
        CheckGround();

        // 애니메이션에 속도 전달
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void FixedUpdate()
    {
        // 이동 반영
        rb.velocity = new Vector2(moveInput * stats.moveSpeed, rb.velocity.y);

        // 점프 실행
        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, stats.jumpForce);
            jumpPressed = false;
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
