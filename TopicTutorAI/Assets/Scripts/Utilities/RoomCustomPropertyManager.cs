using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    public static class RoomCustomPropertyManager
    {
        private static readonly ExitGames.Client.Photon.Hashtable customProperties = new();

        public static bool AddCustomProperty<T>(string key, T value) where T : struct
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            customProperties[key] = value;

            return PhotonNetwork.CurrentRoom.SetCustomProperties(customProperties);
        }

        public static bool RemoveCustomProperty(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            if (!customProperties.ContainsKey(key) ||
                !PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(key))
            {
                return false;
            }

            customProperties.Remove(key);

            return PhotonNetwork.CurrentRoom.CustomProperties.Remove(customProperties[key]);
        }
    }
}
