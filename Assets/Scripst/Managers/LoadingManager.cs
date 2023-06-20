using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LoadingManager : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
            
        }
        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

}
