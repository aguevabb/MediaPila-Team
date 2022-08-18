using UnityEngine;

namespace GT2.Demo
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private TurretAim TurretAim = null;

        public Transform TargetPoint = null;

        public bool isIdle = true;

        private void Awake()
        {
            if (TurretAim == null)
                Debug.LogError(name + ": TurretController not assigned a TurretAim!");
        }

        private void Update()
        {
            if (TurretAim == null)
                return;

            if (TargetPoint == null)
                TurretAim.IsIdle = TargetPoint == null;
            else
                TurretAim.AimPosition = TargetPoint.position;
        }
        public void Idler()
        {
            TurretAim.IsIdle = !TurretAim.IsIdle;
        }
    }
}
