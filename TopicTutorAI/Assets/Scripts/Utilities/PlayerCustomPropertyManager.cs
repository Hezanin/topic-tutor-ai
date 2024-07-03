using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    public static class PlayerCustomPropertyManager
    {
        private static readonly ExitGames.Client.Photon.Hashtable customProperties = new();

        public static bool AddCustomProperty<T>(string key, T value) where T : struct
        {
            if (string.IsNullOrEmpty(key) || !PhotonNetwork.IsConnected)
            {
                return false;
            }

            customProperties[key] = value;

            return PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
        }

        public static bool RemoveCustomProperty(string key)
        {
            if (string.IsNullOrEmpty(key) || !PhotonNetwork.IsConnected)
            {
                return false;
            }

            if (!customProperties.ContainsKey(key) ||
                !PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey(key))
            {
                return false;
            }

            customProperties.Remove(key);

            return PhotonNetwork.LocalPlayer.CustomProperties.Remove(customProperties[key]);
        }
    }
}
