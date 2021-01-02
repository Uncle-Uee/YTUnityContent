using System.IO;
using UnityEngine;

namespace YourProjectName.General.Globals
{
    public static class Constants
    {
        #region VARIABLES

        [Header("System")]
        public static int PAUSE_SPEED = 1;

        #endregion

        #region PROPERTIES

        public static string SaveGame_SA => Path.Combine(Application.streamingAssetsPath, "save.json");
        public static string SaveGame_PD => Path.Combine(Application.persistentDataPath, "save.json");
        public static string SaveGame_DP => Path.Combine(Application.dataPath, "save.json");

        #endregion

        #region METHODS

        #endregion
    }
}