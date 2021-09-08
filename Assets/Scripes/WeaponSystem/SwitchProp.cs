using UnityEngine;
public class SwitchProp : MonoBehaviour
{
    private TankSwitchPart swi; //获取PlayerTank上的TankSwitchPart
    [SerializeField]private int switchNumber;   //设置更换的Turret编号
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player"&&
            other.gameObject.GetComponent<TankSwitchPart>()!=null)
        {
            swi = other.gameObject.GetComponent<TankSwitchPart>();
            swi.SwitchTurret(switchNumber);
            Destroy(this.gameObject);
        }
    }
}
