using System;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

namespace Controllers.Base
{
    public class BaseCharAnimationController : MonoBehaviour
    {
        private UnityArmatureComponent _armatureComponent;
        public UnityArmatureComponent ArmatureComponent
        {
            get
            {
                return _armatureComponent;
            }
        }

        private void Awake()
        {
            _armatureComponent = GetComponent<UnityArmatureComponent>();
            _armatureComponent._sortingOrder = 3;
        }

        public void SetActiveAnimation(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}