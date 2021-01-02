using UnityEngine;

namespace YourProjectName.Systems
{
    public abstract class HealthSystem : MonoBehaviour
    {
        #region METHODS

        public abstract void ResetHealth();
        public abstract void GetHealth(float value);
        public abstract void LoseHealth(float value);

        #endregion
    }
}