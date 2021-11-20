using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PathsController : MonoBehaviour
    {
        [SerializeField] private List<Transform> npcPath;

        public List<Transform> NpcPath
        {
            get
            {
                if (npcPath.Count < 0)
                {
                    return null;
                }

                return npcPath;
            }
        }
    }
}
