using ShadowCube.DTO;
using ShadowCube.Helpers;
using UnityEngine;

namespace ShadowCube.Player
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
    public class PlayerMoveControl : Entity
    {
        [SerializeField] public string NameStage;

        [Header("Components")]
        [SerializeField] public Animator animator;
        [SerializeField] public Rigidbody Rigidbody;
        [SerializeField] public CapsuleCollider capsuleCollider;
        [SerializeField] public CameraTarget cameraTarget;
        [SerializeField] public DetectObject detectObject;

        [Header("Stages")]
        [SerializeField] public bool isJumping = false;
        [SerializeField] public bool isGrounded = false;
        [SerializeField] public bool isSitDown = false;
        [SerializeField] public bool isFreeHang = false;
        [SerializeField] public bool isClimb = false;
        [SerializeField] public bool IsTop = false;

        public InputScheme InputScheme;
        public StageMachine stageMachine;

        private float groundMinDistance = 0.02f;
        private float MaxDistance = 1f;

        protected void Start()
        {
            animator = gameObject.GetComponent<Animator>();
            Rigidbody = gameObject.GetComponent<Rigidbody>();
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();

            InputScheme = new InputScheme();
            stageMachine = new StageMachine( new StageWalk(this) );
        }

        public void MoveCharacter(Vector3 _direction)
        {
            Vector3 inputSmooth = Vector3.zero;
            Vector3 input = Vector3.zero;
            inputSmooth = Vector3.Lerp(inputSmooth, input, 6 * Time.deltaTime);

            _direction.y = Mathf.Clamp(_direction.y, -1f, 1f);
            _direction.x = Mathf.Clamp(_direction.x, -1f, 1f);
            _direction.z = Mathf.Clamp(_direction.z, -1f, 1f);
            // limit the input
            if (_direction.magnitude > 1f)
                _direction.Normalize();

            Vector3 targetPosition = Rigidbody.position + _direction * 1 * Time.deltaTime;
            Vector3 targetVelocity = (targetPosition - transform.position) / Time.deltaTime;

            Rigidbody.velocity = targetVelocity;
        }

        public float CheckDistance(Vector3 direction, int layer = 1)
        {
            float MaxDistance = 10f;
            float dist = MaxDistance;
            Ray ray2 = new Ray(transform.position + new Vector3(0, capsuleCollider.height / 2, 0), direction);
            RaycastHit groundHit;
            if (Physics.Raycast(ray2, out groundHit, (capsuleCollider.height / 2) + MaxDistance, layer) && !groundHit.collider.isTrigger)
            {
                dist = groundHit.distance;
            }
            return (float)System.Math.Round(dist, 2);
        }

        public void Update()
        {
            NameStage = stageMachine.CurrentStage.GetType().Name;
            stageMachine.CurrentStage.Update();
        }

        public void RotateToDirection(Vector3 direction, float rotationSpeed)
        {
            //if (!jumpAndRotate && !isGrounded) return;
            direction.y = 0f;
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, direction.normalized, rotationSpeed * Time.deltaTime, .1f);
            Quaternion _newRotation = Quaternion.LookRotation(desiredForward);
            transform.rotation = _newRotation;
        }

        public void CheckGround()
        {
            float dist = CheckDistance(-Vector3.up) - (capsuleCollider.height / 2);
            isGrounded = dist < groundMinDistance;
        }

        public void CheckTop()
		{
            float dist = CheckDistance(Vector3.up);
            IsTop = dist < MaxDistance;
        }
    }
}