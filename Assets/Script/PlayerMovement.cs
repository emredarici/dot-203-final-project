using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;
    public float sideSpeed;
    private CoinManager coinCont;
    public GameManager levelUp;

    void Start()
    {
        coinCont = GameObject.Find("Player").GetComponent<CoinManager>();

        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.AddForce(0, 0, moveSpeed * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideSpeed, 0, 0 * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideSpeed, 0, 0 * Time.deltaTime);
        }
        if (rb.position.y < -2f && coinCont.coin < 5)
        {
            FindObjectOfType<GameManager>().gameOver();

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");
            sideSpeed = 0f;
            moveSpeed = 0f;
            FindObjectOfType<GameManager>().gameOver();

        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Castle"))
        {
            if (coinCont.coin == 5)
            {

                FindObjectOfType<GameManager>().levelUp();
            }
            else
            {
                FindObjectOfType<GameManager>().gameOver();

            }
        }
    }
}
