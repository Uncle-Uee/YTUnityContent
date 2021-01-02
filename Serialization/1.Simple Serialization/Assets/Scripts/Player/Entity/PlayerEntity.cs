using UnityEngine;

namespace YourProjectName.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        #region VARIABLES

        [Header("Systems")]
        public PlayerHealth PlayerHealth;
        public PlayerShield PlayerShield;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion

        #region SETUP METHODS

        private void Initialize()
        {
            PlayerHealth.ResetHealth();
            PlayerShield.ResetShield();
        }

        private void Terminate()
        {
        }

        #endregion

        #region HEALTH METHODS

        public void GetHealth(float value) => PlayerHealth.GetHealth(value);
        private void LoseHealth(float value) => PlayerHealth.LoseHealth(value);

        #endregion

        #region SHIELD METHODS

        public void GetShield(float value) => PlayerShield.GetShield(value);
        private void LoseShield(float value) => PlayerShield.LoseShield(value);

        #endregion

        #region METHODS

        public void TakeDamage(float value)
        {
            if (!PlayerHealth.IsAlive) return;

            if (PlayerShield.HasShield)
                LoseShield(value);
            else
                LoseHealth(value);
        }

        #endregion
    }
}