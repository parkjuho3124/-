using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("�̵� ����")]
    private float moveInput;
    private bool isGrounded;
    private bool jumpPressed;

    [Header("���� üũ")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("���� ������Ʈ")]
    private Rigidbody2D rb;
    private Animator anim;

    [Header("�÷��̾� ����")]
    public PlayerStats stats; //  ����: PlayerStats.cs

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // �¿� �̵� �Է�
        moveInput = Input.GetAxisRaw("Horizontal");

        // ��������Ʈ ���� ��ȯ
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }

        // ���� �Է�
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;
        }

        // ���� üũ
        CheckGround();

        // �ִϸ��̼ǿ� �ӵ� ����
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void FixedUpdate()
    {
        // �̵� �ݿ�
        rb.velocity = new Vector2(moveInput * stats.moveSpeed, rb.velocity.y);

        // ���� ����
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
