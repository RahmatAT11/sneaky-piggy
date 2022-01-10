using UnityEngine;

namespace Controllers.Base
{
    public class BaseCharController : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody2D;
    
        // movement
        protected float MovementSpeed = 2.0f;
        protected float SprintSpeedMultiplier = 5f;
        protected Vector3 MovementDirection;
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
    
        protected virtual void Walking()
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + 
                                     (Vector2)(MovementDirection * (MovementSpeed * Time.fixedDeltaTime)));
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
                                     (Vector2)(MovementDirection * (MovementSpeed * SprintSpeedMultiplier
                                     * Time.fixedDeltaTime)));
        }
    }
}
