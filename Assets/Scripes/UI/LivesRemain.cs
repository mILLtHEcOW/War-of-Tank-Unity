using UnityEngine;
using UnityEngine.UI;
public class LivesRemain : MonoBehaviour
{
    public GameObject Player;
    public Text livesText;

    void Update()
    {
        livesText.text = Player.GetComponent<TankHealthPlayer>().lives.ToString();    
    }
}
