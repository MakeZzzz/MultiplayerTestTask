using System;
using System.Text;
using Models;
using UnityEngine;

namespace Systems
{
    public static class PhotonSerializeSystem
    {
        public static object DeserializePlayerModel(byte[] data)
        {
            var color = new Color
            {
                r = BitConverter.ToSingle(data, 0),
                g = BitConverter.ToSingle(data, 4),
                b = BitConverter.ToSingle(data, 8),
                a = BitConverter.ToSingle(data, 12)
            };

            var health = BitConverter.ToInt32(data, 16);
            var countCoins = BitConverter.ToInt32(data, 20);
            var colorName = Encoding.UTF8.GetString(data, 24, data.Length - 24);;
            var result = new PlayerModel(colorName,color, health, countCoins);
            
            return result;
        }

        public static byte[] SerializePlayerModel(object obj)
        {
            var playerModel = (PlayerModel) obj;
            var colorNameBytes = Encoding.UTF8.GetBytes(playerModel.ColorName);;
            var result = new byte[24 + colorNameBytes.Length];
        
            BitConverter.GetBytes(playerModel.Color.r).CopyTo(result, 0);
            BitConverter.GetBytes(playerModel.Color.g).CopyTo(result, 4);
            BitConverter.GetBytes(playerModel.Color.b).CopyTo(result, 8);
            BitConverter.GetBytes(playerModel.Color.a).CopyTo(result, 12);
            BitConverter.GetBytes(playerModel.Health).CopyTo(result, 16);
            BitConverter.GetBytes(playerModel.CountCoins).CopyTo(result, 20);
            
            colorNameBytes.CopyTo(result, 24);
            return result;
        }
    }
}