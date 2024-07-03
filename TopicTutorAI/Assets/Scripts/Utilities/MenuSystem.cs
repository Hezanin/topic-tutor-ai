
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    [SerializeField]
    private Button menuScreenButton;

    [SerializeField]
    private Button profileScreenButton;

    [SerializeField]
    private Button leaderboardScreenButton;

    // Start is called before the first frame update
    void Start()
    {
        this.menuScreenButton.onClick.AddListener(MenuScreenButton_OnClick);
        this.profileScreenButton.onClick.AddListener(ProfileScreenButton_OnClick);
        this.leaderboardScreenButton.onClick.AddListener(LeaderboardScreenButton_OnClick);
    }

    private void LeaderboardScreenButton_OnClick()
    {
        Debug.Log("leaderboard");
        DisconnectPhotonNetwork();
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single);
    }

    private void ProfileScreenButton_OnClick()
    {
        Debug.Log("profile");
        DisconnectPhotonNetwork();
        SceneManager.LoadScene("Profile", LoadSceneMode.Single);
    }

    private void MenuScreenButton_OnClick()
    {
        Debug.Log("menu");
        DisconnectPhotonNetwork();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    private void DisconnectPhotonNetwork()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }
}
