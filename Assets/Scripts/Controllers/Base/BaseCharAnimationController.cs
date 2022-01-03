using DragonBones;
using UnityEngine;

namespace Controllers.Base
{
    public class BaseCharAnimationController : MonoBehaviour
    {
        [SerializeField] private UnityArmatureComponent armatureComponent;
        public UnityArmatureComponent ArmatureComponent
        {
            get
            {
                return armatureComponent;
            }
        }
    }
}