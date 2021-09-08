using UnityEngine;

public class LerpCamera : MonoBehaviour
{
    public Vector3 centor=Vector3.zero;
    public float offset= 0.7f;
    public GameObject player;

    private void LateUpdate()
    {
        if(player!=null)
        this.transform.position = (player.transform.position - centor) * offset;
    }
}
