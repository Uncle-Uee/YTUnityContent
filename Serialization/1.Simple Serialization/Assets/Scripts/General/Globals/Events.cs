using System;
using UnityEngine;

namespace YourProjectName.General.Globals
{
    public static class Events
    {
        #region EVENTS

        [Header("System")]
        public static Action OnSave;
        public static Action OnLoad;

        #endregion
    }
}