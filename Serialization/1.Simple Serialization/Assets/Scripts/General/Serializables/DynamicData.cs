using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YourProjectName.General.Globals;

namespace YourProjectName.General
{
    [Serializable]
    public class PlayerData
    {
        #region VARIABLES

        [Header("Player Data")]
        public float PlayerHealth;
        public float PlayerShield;

        public List<string> Aliases = new List<string>();

        #endregion
    }

    [Serializable]
    public class DynamicData : ISaveable
    {
        #region VARIABLES

        public PlayerData PlayerData;

        #endregion

        #region SERIALIZATION METHODS

        public void Serialize()
        {
            string data = JsonUtility.ToJson(this, true);
            File.WriteAllText(Constants.SaveGame_DP, data);
        }

        public void Deserialize()
        {
            string data = File.ReadAllText(Constants.SaveGame_DP);
            JsonUtility.FromJsonOverwrite(data, this);
        }

        public void RegisterSerializationEvents()
        {
            Events.OnSave += Serialize;
            Events.OnLoad += Deserialize;
        }

        #endregion
    }
}