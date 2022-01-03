using UnityEngine;

namespace Controllers.Base
{
    public class BaseCharController : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody2D;
    
        [Header("Movement")]
        [SerializeField] protected float movementSpeed = 2.0f;
        protected Vector3 MovementDirection;
        public Vector3 MovementDirectionEx
        {
            get
            {
                return MovementDirection;
            }
        }
        protected bool IsSprinting;
        public bool IsSprintingEx
        {
            get
            {
                return IsSprinting;
            }
            set
            {
                IsSprinting = value;
            }
        }
        [SerializeField] protected float sprintSpeedMultiplier = 5f;
    
        protected virtual void Walking()
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + 
                                     (Vector2)(MovementDirection * movementSpeed* Time.fixedDeltaTime));
        }
    
        protected virtual void Turning()
        {
            // rotate if vector _movementDirection is not zero
            if (MovementDirection == Vector3.zero) return;
            
            Quaternion rotation = Quaternion.LookRotation(MovementDirection, Vector3.back);
            Rigidbody2D.MoveRotation(rotation);
        }
        
        protected virtual void Sprinting()
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + 
                                     (Vector2)(MovementDirection * movementSpeed * sprintSpeedMultiplier
                                     * Time.fixedDeltaTime));
        }
    }
}
