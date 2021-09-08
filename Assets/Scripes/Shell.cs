using System.Collections;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosionEffect;
    private float explosionTimeUP = 1.5f;
    private int damage = 10;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || 
            other.gameObject.tag == "Enemy"||
            other.gameObject.tag == "Base")//判断Tag
            if(other.transform.tag != this.tag &&
               other.gameObject.GetComponent<Health>()!=null)
            {
                other.gameObject.GetComponent<Health>().ApplyDamage(damage);
            }
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);//摧毁炮弹
        Destroy(obj, explosionTimeUP);//摧毁炮弹特效
    }
}
