using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public AudioSource ding;
    public AudioSource flapSound;
    public AudioSource hitSound;
    public bool birdIsAlive = true;
    [SerializeField]private float velocity;
    [SerializeField]private float rotationSpeed;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        birdMoveWhenFlying();

        // Check for touch input
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            flapSound.Play();
        }

        // Optional: Keep spacebar support for testing in the editor
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            flapSound.Play();
        }
#endif
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        hitSound.Play();
        //Destroy(gameObject);
        if (collision.gameObject.layer == 3) {
            logic.addScore(0);
           
        }

    }
    private void birdMoveWhenFlying() {
        transform.rotation = Quaternion.Euler(0, 0, myRigidBody.linearVelocity.y * rotationSpeed);
    }
}
