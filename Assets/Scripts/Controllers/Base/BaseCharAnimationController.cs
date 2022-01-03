using System.Collections.Generic;
using DragonBones;
using UnityEngine;

namespace Controllers.Base
{
    public class BaseCharAnimationController : MonoBehaviour
    {
        [SerializeField] private List<UnityDragonBonesData> animationData;
        [SerializeField] private UnityArmatureComponent armatureComponent;
        public UnityArmatureComponent ArmatureComponent
        {
            get
            {
                return armatureComponent;
            }
        }

        public void ChangeAnimationData(int index)
        {
            if (index < animationData.Count)
            {
                armatureComponent.unityData = animationData[index];
            }

            var dragonBonesData = UnityFactory.factory.LoadData(armatureComponent.unityData);
            if (dragonBonesData != null && !string.IsNullOrEmpty(armatureComponent.armatureName))
            {
                UnityFactory.factory.BuildArmatureComponent(
                    armatureComponent.armatureName, 
                    armatureComponent.unityData.dataName, null, null, gameObject);
            }
            
            armatureComponent._sortingOrder = 3;
        }
    }
}