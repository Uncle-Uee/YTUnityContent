using UnityEngine;

namespace YourProjectName.Systems
{
    public abstract class ShieldSystem : MonoBehaviour
    {
        #region METHODS

        public abstract void ResetShield();
        public abstract void GetShield(float value);
        public abstract void LoseShield(float value);

        #endregion
    }
}