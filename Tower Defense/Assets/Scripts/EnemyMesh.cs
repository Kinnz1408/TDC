using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMesh : MonoBehaviour
{
     public Transform target;
    [HideInInspector] private string NameToStats;
    [HideInInspector] private bool AttackEnable;
    [HideInInspector] NavMeshAgent agent;
    [HideInInspector] public GameObject NameEnemy; 
    [HideInInspector] GameObject FinalDestinationObject;  
    [HideInInspector] private float ResetTimetoAttack;
    [HideInInspector] private Stats EnemyStats;
    [HideInInspector] public bool Tower;
    TowerScript ThisTower;
    FieldOfView my_FieldOfView;
 
    SpawnPlayer spawnPlayer;

    [Header("Core")]
    public string FinalDestinationName;
    public string TagToChase;
    public float TimeBetweenAttack;
    public Vector3 RangedToAtk;


    public int HP;
    public int attack;
    public int Defense;
    bool Enemy;

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
       
        Tower = false;
        Enemy = false;
        AttackEnable = false;
        ResetTimetoAttack = TimeBetweenAttack;





        my_FieldOfView = GetComponent<FieldOfView>();

        
        FinalDestinationObject = GameObject.Find(FinalDestinationName);
        target = GameObject.Find(FinalDestinationName).transform;
        


    }

    // Update is called once per frame
    void Update()
    {
        target = my_FieldOfView.My_target;
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
        else
        {
            AttackEnable = true;
            Enemy = true;
            // Debug.Log("Achei um alvo");

            NameEnemy = target.gameObject;
            PrintDraw();
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





    void Attack()
    {
        Debug.Log("Achei um alvo");
        EnemyStats = NameEnemy.GetComponent<Stats>();

        if (Enemy)
        {

            EnemyStats.HP -= attack / (2 + EnemyStats.Defense / 100);


        }


        if (Tower)
        {

            //  ThisTower.HP -= 20;
        }




    }
    void Move()
    {

      

            agent.SetDestination(target.position);
        



    }
    void PrintDraw()
    {
        if (target != null)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            Debug.DrawLine(new Vector3(transform.position.x, transform.position.y / 2, transform.position.z), target.transform.position, Color.red);
            //  Debug.DrawRay(new Vector3(transform.position.x + my_FieldOfView.viewRadius, transform.position.y / 2, transform.position.z), target.transform.position, Color.black);

        }

    }
}