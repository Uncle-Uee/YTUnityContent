using UnityEngine;
using YourProjectName.General;
using YourProjectName.Managers;
using YourProjectName.Systems;

namespace YourProjectName.Player
{
    public class PlayerHealth : HealthSystem
    {
        #region VARIABLES

        [Header("Variables")]
        public Variables Variables;

        [Header("Health")]
        public float Health = 0f;
        public float CurrentHealth = 0f;

        #endregion

        #region PROPERTIES

        public bool IsAlive => CurrentHealth > 0;

        #endregion

        #region METHODS

        public override void ResetHealth()
        {
            CurrentHealth = Health = Variables.Health;
        }

        public override void GetHealth(float value)
        {
            CurrentHealth += value;
            if (CurrentHealth > Health) CurrentHealth = Health;
        }

        public override void LoseHealth(float value)
        {
            if (!IsAlive) return;

            CurrentHealth -= value;
            if (CurrentHealth < 0) CurrentHealth = 0;
        }

        #endregion
    }
}