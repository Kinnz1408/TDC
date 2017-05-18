using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navmesh : MonoBehaviour
{


    [HideInInspector] public Transform target;
    private string NameToStats;
    public bool AttackEnable;
    [HideInInspector] NavMeshAgent agent;
    [HideInInspector] FieldOfView my_FieldOfView;
    [HideInInspector] public GameObject NameEnemy;

    GameObject FinalDestinationObject;
    [HideInInspector] public bool Enemy;
    [HideInInspector] public bool Tower;

    [HideInInspector] public float ResetTimetoAttack;
    [HideInInspector] private Stats EnemyStats;

    // TowerScript ThisTower;

    SpawnPlayer spawnPlayer;


    [Header("Core")]
    public string FinalDestinationName;
    public string TagToChase;
    public float TimeBetweenAttack;
    public Vector3 RangedToAtk;
    [Header("Tô fazendo")]
    public int HP;
    public int attack;
    public int Defense;


    //Para bruno 




    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("TowerA") == null)
        {
            FinalDestinationName = "TowerA (1)";

        }
        if (GameObject.Find("TowerA (1)") == null)
        {
            FinalDestinationName = "TowerA";

        }

        agent = GetComponent<NavMeshAgent>();
        my_FieldOfView = GetComponent<FieldOfView>();
        spawnPlayer = GameObject.Find("Ui").GetComponent<SpawnPlayer>();







        FinalDestinationName = spawnPlayer.FinalDestination;
        FinalDestinationObject = GameObject.Find(spawnPlayer.FinalDestination);








        target = GameObject.Find(FinalDestinationName).transform;




        Enemy = false;
        Tower = false;
        AttackEnable = false;
        ResetTimetoAttack = TimeBetweenAttack;











    }

    // Update is called once per frame
    void Update()
    {
        target = my_FieldOfView.My_target;

        // this_agent.target = target;




        if (GameObject.Find("TowerA") == null)
        {
            FinalDestinationName = "TowerA (1)";
            FinalDestinationObject = GameObject.Find(FinalDestinationName);

        }
        if (GameObject.Find("TowerA (1)") == null)
        {
            FinalDestinationName = "TowerA";
            FinalDestinationObject = GameObject.Find(FinalDestinationName);

        }


        if (!this.target)
        {
            AttackEnable = false;
            target = FinalDestinationObject.transform;
           // Debug.Log("Objeto está vazio");
            Enemy = false;
        }
        else
        {
            AttackEnable = true;
           // Debug.Log("Achei um alvo");
            Enemy = true;
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



    void PrintDraw()
    {
        if (target != null)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            Debug.DrawLine(new Vector3(transform.position.x, transform.position.y / 2, transform.position.z), target.transform.position, Color.blue);
            //  Debug.DrawRay(new Vector3(transform.position.x + my_FieldOfView.viewRadius, transform.position.y / 2, transform.position.z), target.transform.position, Color.black);

        }

    }



}
