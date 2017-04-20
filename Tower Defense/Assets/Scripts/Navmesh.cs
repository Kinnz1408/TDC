using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navmesh : MonoBehaviour
{
    public Transform target;
    private string NameToStats;
    private bool AttackEnable;
    NavMeshAgent agent;
    public bool CheckNav;
    public GameObject NameEnemy;
    public string FinalDestinationName;
    GameObject FinalDestinationObject;
    public string TagToChase;
    public float TimeBetweenAttack;
    private float ResetTimetoAttack;
    private Stats EnemyStats;
    public bool Enemy;
    public bool Tower;
    TowerScript ThisTower;
    public Vector3 RangedToAtk;

    // Use this for initialization
    void Start()
    {
        Enemy = false;
        Tower = false;
        AttackEnable = false;
        ResetTimetoAttack = TimeBetweenAttack;
        agent = GetComponent<NavMeshAgent>();
        FinalDestinationObject = GameObject.Find(FinalDestinationName);
        target = FinalDestinationObject.transform;
        ThisTower = GameObject.Find(FinalDestinationName).GetComponent<TowerScript>();

    }

    // Update is called once per frame
    void Update()
    {

       






    }



    IEnumerator AttackEnemyEnumerator()
    {
        Attack();
        yield return new WaitForSeconds(TimeBetweenAttack);
    }
    private void FixedUpdate()
    {
        if (!this.target)
        {
            AttackEnable = false;
            target = FinalDestinationObject.transform;
            Debug.Log("Objeto está vazio");
            Enemy = false;

        }
        Move();

        // Combat 
        if (AttackEnable == true)
        {

            if (ResetTimetoAttack <= 0)
            {
                StartCoroutine(AttackEnemyEnumerator());
                ResetTimetoAttack = TimeBetweenAttack;
            }
            ResetTimetoAttack -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        {
            if (collision.gameObject.tag == TagToChase)
            {
                //   string contact = collision.transform.name;
                Enemy = true;
                AttackEnable = true;
                string contact2 = collision.gameObject.name;
                NameEnemy = GameObject.Find(contact2);
                target = this.NameEnemy.transform;
                NameToStats = contact2;
                Debug.Log(contact2);
                EnemyStats = GameObject.Find(NameToStats).GetComponent<Stats>();
            }
            if (collision.gameObject.name == FinalDestinationName)
            {
                //   string contact = collision.transform.name;
                Tower = true;
                AttackEnable = true;
                string contact2 = collision.gameObject.name;
                NameEnemy = GameObject.Find(contact2);
                target = this.NameEnemy.transform;
                NameToStats = contact2;
                //  Debug.Log(contact2);

            }
        }
    }
    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == TagToChase)
        {
            //   string contact = collision.transform.name;
            Enemy = true;
            AttackEnable = true;
            string contact2 = other.gameObject.name;
            NameEnemy = GameObject.Find(contact2);
            target = this.NameEnemy.transform;
            NameToStats = contact2;
            Debug.Log(contact2);
            EnemyStats = GameObject.Find(NameToStats).GetComponent<Stats>();
        }
        if (other.gameObject.name == FinalDestinationName)
        {
            //   string contact = collision.transform.name;
            Tower = true;
            AttackEnable = true;
            string contact2 = other.gameObject.name;
            NameEnemy = GameObject.Find(contact2);
            target = this.NameEnemy.transform;
            NameToStats = contact2;
            //  Debug.Log(contact2);

        }


    }
    

        void Attack() {

        if (Enemy) {
            EnemyStats.HP -= EnemyStats.DamageToDeal;
        }


        if (Tower) {
       //     Debug.Log("Ataquei a Torre , viu");
            ThisTower.HP -= 20;
        }
           
        
        
        
    }
    void Move (){

        if (Enemy)
        {
            agent.SetDestination(target.position);
        }
        else if (Tower) {
            agent.SetDestination(target.position - RangedToAtk);

        }else 
        {

            agent.SetDestination(target.position);
        }
        


    }



}
