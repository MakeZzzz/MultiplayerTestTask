using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace Managers
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _createInput;
        [SerializeField] private TMP_InputField _joinInput;

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }

}
