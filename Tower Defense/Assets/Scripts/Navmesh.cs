using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// ESSE FUNCIONA FILHO DA PUTA !!!!!!!!!!!!!
public class Navmesh : MonoBehaviour
{
    private Transform target;
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

        if (!this.target)
        {
            AttackEnable = false;
            target = FinalDestinationObject.transform;
            Debug.Log("Objeto está vazio");
            Enemy = false;
        }

        agent.SetDestination(target.position);

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
                EnemyStats=GameObject.Find(NameToStats).GetComponent<Stats>();
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
                Debug.Log(contact2);
                
            }
        }
}

    void Attack() {

        if (Enemy) {
            EnemyStats.HP -= EnemyStats.DamageToDeal;
        }


        if (Tower) {
            Debug.Log("Ataquei a Torre , viu");
            ThisTower.HP -= 20;
        }
           
        
        
        
    }



}
