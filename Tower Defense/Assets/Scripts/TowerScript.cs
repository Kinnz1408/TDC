using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    [HideInInspector] private Transform target;
    [HideInInspector] private string NameToStats;
    [HideInInspector] private bool AttackEnable;
    [HideInInspector] public GameObject NameEnemy;
    [HideInInspector] public float ResetTimetoAttack;
    [HideInInspector] public Stats EnemyStats;
    [HideInInspector] public Transform Bullet;
    [HideInInspector] public Transform SpawnPoint;


    Ui ui;

    [Header("Core")]
    public bool isAEnemyTower;
    public string TagToChase;
    public float TimeBetweenAttack;


    // Status Torre
    [Header("Status")]
    //  public int Level;
    //	public int HP;
    //	public int Atk;
    //   public bool Ok;


    FieldOfView my_FieldOfView;
    Stats my_stats;

    // Use this for initialization
    void Start()
    {

        AttackEnable = false;
        ResetTimetoAttack = TimeBetweenAttack;
        ui = GameObject.Find("Ui").GetComponent<Ui>();
        my_FieldOfView = GetComponent<FieldOfView>();
        my_stats = GetComponent<Stats>();

    }

    // Update is called once per frame
    void Update()
    {
        PrintDraw();

        target = my_FieldOfView.My_target;


        if (my_stats.HP <= 0)
        {

            Destroy(gameObject);
        }





        if (!this.target)
        {
            AttackEnable = false;



        }
        else
        {
            AttackEnable = true;
            Debug.Log(target.gameObject.name);
            NameEnemy = target.gameObject;
            PrintDraw();


        }


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




    void Attack()
    {


        Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
        //  EnemyStats.HP -= ((Atk * (2 ^ Level)) + Level * 550) / 2;




    }

    void OnMouseDown()
    {
        if (!isAEnemyTower)
        {
            if (this.gameObject.name == "TowerB")
            {
                ui.TowerCanvas();
            }
            else ui.TowerCanvas01();

        }
        else Debug.Log("Essa é uma Torre Inimiga");




    }

    void PrintDraw()
    {
        if (target != null)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            Debug.DrawLine(new Vector3(transform.position.x, transform.position.y / 2, transform.position.z), target.transform.position, Color.yellow);
          //  Debug.DrawRay(new Vector3(transform.position.x + my_FieldOfView.viewRadius, transform.position.y / 2, transform.position.z), target.transform.position, Color.black);

        }
       
    }
    void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawSphere(transform.position, my_FieldOfView.viewRadius);




    }
}