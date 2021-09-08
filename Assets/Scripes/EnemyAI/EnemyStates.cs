using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour
{
    public States State = States.patrol;//初始化状态
    private float distendFormPlayer; //声明玩家距离
    private float distendFormBase; //声明基地距离
    private GameObject Player;  //声明玩家
    private GameObject Base;   //声明基地
    private NavMeshAgent nav; //声明寻路特工
    [SerializeField]private Vector3 target = Vector3.zero;//目标
    private IEnemyShot ES => GetComponentInChildren<IEnemyShot>();
    public float stoppingDistance = 1.5f;
    public float rayDistance = 5f; //阻挡检测ray距离
    private LayerMask TankLayerMask = 10; //阻挡检测LayerMask
    bool canShoot = true;
    public Ray ray;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Base = GameObject.FindWithTag("Base");//获取玩家与基地；
        distendFormPlayer = Vector3.Distance(this.transform.position, Player.transform.position);
        distendFormBase = Vector3.Distance(this.transform.position, Base.transform.position);
        nav = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        switch (State)//状态机Switch
        {
            case States.patrol:
                {
                    if (NeedTarget())
                    {
                        target = GetRandomPosition();
                    }
                    if (IsBlocked())
                    {
                        target = GetRandomPosition();
                    }
                    nav.destination = target;
                    if (Vector3.Distance(this.transform.position, Player.transform.position) < 20f)
                        State = States.attackPlayer;
                    if (Vector3.Distance(this.transform.position, Base.transform.position) < 20f)
                        State = States.attackPlayerBase;
                    break;
                }
            case States.attackPlayer:
                {
                    if (NeedTarget())
                    {
                        State = States.patrol;
                    }
                    target = Player.transform.position;
                    nav.destination = target;
                    this.transform.LookAt(target);
                    if (canShoot)
                    {
                        ES.Shoot();
                        canShoot = false;
                        StartCoroutine(CoolDown());
                    }
                    if (Vector3.Distance(this.transform.position, Player.transform.position) > 14f)
                    {
                        State = States.patrol;
                    }
                    break;
                }
            case States.attackPlayerBase:
                {   if (NeedTarget())
                {
                    State = States.patrol;
                }
                if (Base != null)
                {
                    target = Base.transform.position;
                }
                nav.destination = target;
                this.transform.LookAt(target);
                nav.stoppingDistance = 4f;
                if (canShoot)
                {
                    ES.Shoot();
                    canShoot = false;
                    StartCoroutine(CoolDown());
                }
                break; }
        }
        ray = new Ray(transform.position+new Vector3(0,1,0), transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward * rayDistance, Color.red);
        if(Physics.Raycast(ray, out hitInfo,rayDistance, TankLayerMask))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
        }
    }

    private bool NeedTarget()
    {
        if (target == Vector3.zero ||
            target == null)
        {
            return true;
        }

        float distance = Vector3.Distance(transform.position, target);

        if (distance <= stoppingDistance)
        {
            return true;
        }
        return false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 5f)) +
                                new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f));
        return testPosition;
    }

    private bool IsBlocked()
    {
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, TankLayerMask);
        return hitInfo.collider != null;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(Random.Range(2, 3));
        canShoot = true;
    }
}

public enum States
{
    patrol,
    attackPlayer,
    attackPlayerBase
}