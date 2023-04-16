using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerinput;
    public InputAction inputaction;
    public Rigidbody rigidbody;
    public float movementforce = 15f;
    public float maxspeed = 5;
    public Vector3 direction = Vector3.zero;
    public Camera camera;
    public float jumpforce = 5;
    public Animator playeranimator;
    public float maximumspeed = 15;
    public float minimumspeed = 5;
    [SerializeField] LayerMask groundMask;
    public Vector3 jumpForce;
    public CinemachineVirtualCamera virtualcamera;
    public MultiAimConstraint MultiAimBody;
    public TwoBoneIKConstraint LeftHandBone;
    public GameObject Gun;
    public static CinemachineFreeLook freelookcamera;
    public GameObject WalkingSound;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerinput = new PlayerInput();
        inputaction = new InputAction();
    }


    void FixedUpdate()
    {
        direction += inputaction.ReadValue<Vector2>().x * GetCameraRight(camera) * movementforce;
        direction += inputaction.ReadValue<Vector2>().y * GetCameraForward(camera) * movementforce;

        rigidbody.AddForce(direction, ForceMode.Impulse);


        if (rigidbody.velocity.y < 0f)
            rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxspeed * maxspeed)
            rigidbody.velocity = horizontalVelocity.normalized * maxspeed + Vector3.up * rigidbody.velocity.y;

        look();
        direction = Vector3.zero;

        if (playerinput.Player.Move.IsPressed())
        {
            playeranimator.SetBool("walk", true);
            virtualcamera.Priority = 5;
            playeranimator.SetBool("aim", false);
            MultiAimBody.weight = 0;
            LeftHandBone.weight = 0;
            Gun.SetActive(false);
            WalkingSound.SetActive(true);
        }
        if (!playerinput.Player.Move.IsPressed())
        {
            playeranimator.SetBool("walk", false);
            playeranimator.SetBool("aim", false);
            virtualcamera.Priority = 5;
            MultiAimBody.weight = 0;
            LeftHandBone.weight = 0;
            Gun.SetActive(false);
            WalkingSound.SetActive(false);
        }
        if (!playerinput.Player.Jump.IsPressed())
        {
            playeranimator.SetBool("jump", false);
        }
        if (playerinput.Player.increasespeed.IsPressed() && playerinput.Player.Move.IsPressed())
        {
            movementforce = maximumspeed;
            playeranimator.SetBool("run", true);
        }
        if (!playerinput.Player.increasespeed.IsPressed())
        {
            movementforce = minimumspeed;
            playeranimator.SetBool("run", false);
        }
        aiming();
    }
    void look()
    {
        Vector3 direction = rigidbody.velocity;
        direction.y = 0f;
        if (inputaction.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            Quaternion roat = Quaternion.LookRotation(direction, Vector3.up);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, roat, 10 * Time.deltaTime);
        }
        else
        {
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forwardcamera = camera.transform.forward;
        forwardcamera.y = 0;
        return forwardcamera.normalized;
    }
    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 forwardcamera = camera.transform.right;
        forwardcamera.y = 0;
        return forwardcamera.normalized;
    }

    private void OnEnable()
    {
        playerinput.Player.Jump.started += dojump;
        playerinput.Player.increasespeed.started += dospeed;
        inputaction = playerinput.Player.Move;
        playerinput.Player.Enable();
    }

    private void OnDisable()
    {
        playerinput.Player.Jump.started -= dojump;
        playerinput.Player.increasespeed.started -= dospeed;
        playerinput.Player.Disable();
    }
    void aiming()
    {
        if (playerinput.Player.Aiming.IsPressed())
        {
            virtualcamera.Priority = 20;
            playeranimator.SetBool("aim", true);
            MultiAimBody.weight = 1;
            LeftHandBone.weight = 1;
            Gun.SetActive(true);
        }
        if (!playerinput.Player.Aiming.IsPressed())
        {
            virtualcamera.Priority = 5;
            playeranimator.SetBool("aim", false);
            MultiAimBody.weight = 0;
            LeftHandBone.weight = 0;
            Gun.SetActive(false);
        }
    }
    void dospeed(InputAction.CallbackContext obj)
    {
        if (playerinput.Player.increasespeed.IsPressed())
        {
            movementforce = 50;
        }

    }
    private void dojump(InputAction.CallbackContext obj)
    {

        if (ground())
        {
            playeranimator.SetBool("jump", true);
            rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }
    public bool ground()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            PlayerHealth.instance.HealthBar.value += 20;
        }
    }
}