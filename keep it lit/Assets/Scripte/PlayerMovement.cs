using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour

{
    [Header("Input")]
    //public Control control;
    [Header("Movement")]
    public float moveSpeed;
    public float ActualSpeed;
    public Rigidbody2D rb;
    public Vector2 movment;
    [Header("Animation")]
    public Animator animator;
    [Header("Instance")]
    public static PlayerMovement instance;

    //To make other scripte modify thing in it with PlayerMovement.instance
    private void Awake()
    {
        //control = new Control();

        if (instance != null)
        {
            Debug.Log("there is more than one istance of PlayerMovment");
            return;
        }
        instance = this;

    }

    private void OnEnable()
    {
        //control.Player.Enable();
    }

    private void OnDisable()
    {
        //control.Player.Disable();
    }

    //Set animation and movent + speed
    void Update()
    {
        //actualSpeed
        ActualSpeed = movment.sqrMagnitude;
        //get Input
        // movment = control.Player.Movement.ReadValue<Vector2>();
        //animat
        animator.SetFloat("Horizontal", movment.x);
        animator.SetFloat("Vertical", movment.y);
        animator.SetFloat("Speed", movment.sqrMagnitude);
    }

    //Move
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * moveSpeed * Time.fixedDeltaTime);
    }

}
