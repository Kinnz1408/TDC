using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMesh : MonoBehaviour
{
    [HideInInspector] public Transform target;
    [HideInInspector] private string NameToStats;
    [HideInInspector] private bool AttackEnable;
    [HideInInspector] NavMeshAgent agent;
    [HideInInspector] public GameObject NameEnemy; 
    [HideInInspector] GameObject FinalDestinationObject;  
    [HideInInspector] private float ResetTimetoAttack;
    [HideInInspector] private Stats EnemyStats;
    [HideInInspector] public bool Enemy;
    [HideInInspector] public bool Tower;
    TowerScript ThisTower;
  
    SpawnPlayer spawnPlayer;

    [Header("Core")]
    public string FinalDestinationName;
    public string TagToChase;
    public float TimeBetweenAttack;
    public Vector3 RangedToAtk;

    void Start()
    {

        if (GameObject.Find("TowerB") == null)
        {
            FinalDestinationName = "TowerB (1)";

        }
        if (GameObject.Find("TowerB (1)") == null)
        {
            FinalDestinationName = "TowerB";

        }

        agent = GetComponent<NavMeshAgent>();      
        Enemy = false;
        Tower = false;
        AttackEnable = false;
        ResetTimetoAttack = TimeBetweenAttack;


       


        

        
        FinalDestinationObject = GameObject.Find(FinalDestinationName);
        target = GameObject.Find(FinalDestinationName).transform;
        


    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("TowerB") == null)
        {
            FinalDestinationName = "TowerB (1)";
            FinalDestinationObject = GameObject.Find(FinalDestinationName);

        }
        if (GameObject.Find("TowerB (1)") == null)
        {
            FinalDestinationName = "TowerB";
            FinalDestinationObject = GameObject.Find(FinalDestinationName);

        }



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



    IEnumerator AttackEnemyEnumerator()
    {
        Attack();
        yield return new WaitForSeconds(TimeBetweenAttack);
    }
    private void FixedUpdate()
    {






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
             //   Debug.Log(contact2);
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
                ThisTower = GameObject.Find(FinalDestinationName).GetComponent<TowerScript>();

            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == TagToChase)
        {
            //   string contact = collision.transform.name;
            Enemy = true;
            AttackEnable = true;
            string contact2 = other.gameObject.name;
            NameEnemy = GameObject.Find(contact2);
            target = this.NameEnemy.transform;
            NameToStats = contact2;
          //  Debug.Log(contact2);
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
            ThisTower = GameObject.Find(FinalDestinationName).GetComponent<TowerScript>();

        }


    }


    void Attack()
    {

        if (Enemy)
        {
            EnemyStats.HP -= 10;
        }


        if (Tower)
        {

            ThisTower.HP -= 20;
        }




    }
    void Move()
    {

        if (Enemy)
        {
            agent.SetDestination(target.position);
        }
        else if (Tower)
        {
            agent.SetDestination(target.position - RangedToAtk);

        }
        else
        {

            agent.SetDestination(target.position);
        }



    }
}