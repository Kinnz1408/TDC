using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMesh : MonoBehaviour
{
    public bool IsEnemy;
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
    SpawnPlayer spawnPlayer;

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


       


        ThisTower = GameObject.Find(FinalDestinationName).GetComponent<TowerScript>();

        
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