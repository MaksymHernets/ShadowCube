using ShadowCube.DTO;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMoveControl : Entity , IMoveControl
{
	#region Components
	[SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
	private CapsuleCollider _capsuleCollider;
    #endregion

    private Camera _mainCamera;

    private bool isJumping = false;
    private bool isGrounded = false;
    private bool isSitDown = false;
    private float groundMinDistance = 0.25f;
    private float groundMaxDistance = 0.5f;
    private float groundDistance;
    private float extraGravity = -10f;
    private float verticalVelocity;
    private float heightReached;

    internal Vector3 inputSmooth;
    internal Vector3 input;

    private void Start()
	{
        _mainCamera = Camera.main;

        _animator = gameObject.GetComponent<Animator>();
		_rigidbody = gameObject.GetComponent<Rigidbody>();
		_capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
	}

	public void Update()
	{
		CheckGround();
	}

	public void SitDown()
	{
        isSitDown = !isSitDown;
        _animator.SetBool("Crouch", true);
    }

    public void Jump()
	{
        if (isGrounded == true && isSitDown == false)
		{
            // _rigidbody.AddForce();
            _animator.SetBool("Jump", true);
        }
    }

    public void Forward()
	{
        MoveCharacter(this.transform.forward);
    }

    public virtual void MoveCharacter(Vector3 _direction)
    {
        _animator.SetBool("Walk", true);
        // calculate input smooth
        inputSmooth = Vector3.Lerp(inputSmooth, input, 6 * Time.deltaTime);

        if (!isGrounded || isJumping) return;

        _direction.y = 0;
        _direction.x = Mathf.Clamp(_direction.x, -1f, 1f);
        _direction.z = Mathf.Clamp(_direction.z, -1f, 1f);
        // limit the input
        if (_direction.magnitude > 1f)
            _direction.Normalize();

        Vector3 targetPosition = _rigidbody.position + _direction * 1 * Time.deltaTime;
        Vector3 targetVelocity = (targetPosition - transform.position) / Time.deltaTime;

        bool useVerticalVelocity = true;
        if (useVerticalVelocity) targetVelocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = targetVelocity;
    }

    public void HeadTurn(Vector3 direction)
	{
        _mainCamera.transform.localEulerAngles += direction;
    }

    protected void CheckGround()
    {
        CheckGroundDistance();

        if (groundDistance <= groundMinDistance)
        {
            isGrounded = true;
            if (!isJumping && groundDistance > 0.05f)
                _rigidbody.AddForce(transform.up * (extraGravity * 2 * Time.deltaTime), ForceMode.VelocityChange);

            heightReached = transform.position.y;
        }
        else
        {
            if (groundDistance >= groundMaxDistance)
            {
                // set IsGrounded to false 
                isGrounded = false;
                // check vertical velocity
                verticalVelocity = _rigidbody.velocity.y;
                // apply extra gravity when falling
                if (!isJumping)
                {
                    _rigidbody.AddForce(transform.up * extraGravity * Time.deltaTime, ForceMode.VelocityChange);
                }
            }
            else if (!isJumping)
            {
                _rigidbody.AddForce(transform.up * (extraGravity * 2 * Time.deltaTime), ForceMode.VelocityChange);
            }
        }
    }

    protected virtual void CheckGroundDistance()
    {
        //if (_capsuleCollider != null)
        //{
        //    // radius of the SphereCast
        //    float radius = _capsuleCollider.radius * 0.9f;
        //    var dist = 10f;
        //    // ray for RayCast
        //    Ray ray2 = new Ray(transform.position + new Vector3(0, colliderHeight / 2, 0), Vector3.down);
        //    // raycast for check the ground distance
        //    if (Physics.Raycast(ray2, out groundHit, (colliderHeight / 2) + dist, groundLayer) && !groundHit.collider.isTrigger)
        //        dist = transform.position.y - groundHit.point.y;
        //    // sphere cast around the base of the capsule to check the ground distance
        //    if (dist >= groundMinDistance)
        //    {
        //        Vector3 pos = transform.position + Vector3.up * (_capsuleCollider.radius);
        //        Ray ray = new Ray(pos, -Vector3.up);
        //        if (Physics.SphereCast(ray, radius, out groundHit, _capsuleCollider.radius + groundMaxDistance, groundLayer) && !groundHit.collider.isTrigger)
        //        {
        //            Physics.Linecast(groundHit.point + (Vector3.up * 0.1f), groundHit.point + Vector3.down * 0.15f, out groundHit, groundLayer);
        //            float newDist = transform.position.y - groundHit.point.y;
        //            if (dist > newDist) dist = newDist;
        //        }
        //    }
        //    groundDistance = (float)System.Math.Round(dist, 2);
        //}
    }

    public virtual void RotateToPosition(Vector3 position)
    {
        Vector3 desiredDirection = position - transform.position;
        RotateToDirection(desiredDirection.normalized);
    }

    public virtual void RotateToDirection(Vector3 direction)
    {
        RotateToDirection(direction, 16f);
    }

    public virtual void RotateToDirection(Vector3 direction, float rotationSpeed)
    {
        //if (!jumpAndRotate && !isGrounded) return;
        direction.y = 0f;
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, direction.normalized, rotationSpeed * Time.deltaTime, .1f);
        Quaternion _newRotation = Quaternion.LookRotation(desiredForward);
        transform.rotation = _newRotation;
    }
}

public interface IMoveControl
{
    void SitDown();
    void Jump();
    void HeadTurn(Vector3 direction);

    void Forward();
    void MoveCharacter(Vector3 _direction);

    void RotateToPosition(Vector3 position);
}
