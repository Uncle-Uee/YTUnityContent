using YourProjectName.General;
using UnityEngine;
using YourProjectName.Systems;

namespace YourProjectName.Player
{
    public class PlayerShield : ShieldSystem
    {
        #region VARIABLES

        [Header("Variables")]
        public Variables Variables;

        [Header("Shield")]
        public float Shield = 0f;
        public float CurrentShield = 0f;

        #endregion

        #region PROPERTIES

        public bool HasShield => Shield > 0;

        #endregion

        #region METHODS

        public override void ResetShield()
        {
            CurrentShield = Shield = Variables.Shield;
        }

        public override void GetShield(float value)
        {
            CurrentShield += value;
            if (CurrentShield > Shield) CurrentShield = Shield;
        }

        public override void LoseShield(float value)
        {
            if (!HasShield) return;

            CurrentShield -= value;
            if (CurrentShield < 0) CurrentShield = 0;
        }

        #endregion
    }
}