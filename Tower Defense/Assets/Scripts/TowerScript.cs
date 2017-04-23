using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour {
	private Transform target;
	private string NameToStats;
    private bool AttackEnable;
	public GameObject NameEnemy;
	public string TagToChase;
	public float TimeBetweenAttack;
	public float ResetTimetoAttack;
	public Stats EnemyStats;
    public Transform Bullet;
    public Transform SpawnPoint;
    public bool isAEnemyTower;
    Ui ui;
    public Slider MySlider;





    // Status Torre

    public int Level;
	public int HP;
	public int Atk;





	// Use this for initialization
	void Start () {
        MySlider.maxValue = HP;
		AttackEnable = false;
		ResetTimetoAttack = TimeBetweenAttack;
        ui = GameObject.Find("Ui").GetComponent<Ui>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP< 0){

            Destroy(gameObject);
        }



        MySlider.value = HP;
		
		if (!this.target)
		{
			AttackEnable = false;
		//	target = FinalDestinationObject.transform;
		//	Debug.Log("Objeto está vazio");

		}
			

		// Combat 
		if (AttackEnable == true) {
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
				AttackEnable = true;
				string contact2 = collision.gameObject.name;
				NameEnemy = GameObject.Find(contact2);
				target = this.NameEnemy.transform;
				NameToStats = contact2;
				//Debug.Log(contact2);
				EnemyStats=GameObject.Find(NameToStats).GetComponent<Stats>();
			}
		}
	}
    void OnTriggerStay(Collider collision)
    {
        {
            if (collision.gameObject.tag == TagToChase)
            {
                //   string contact = collision.transform.name;
                AttackEnable = true;
                string contact2 = collision.gameObject.name;
                NameEnemy = GameObject.Find(contact2);
                target = this.NameEnemy.transform;
                NameToStats = contact2;
                //Debug.Log(contact2);
                EnemyStats = GameObject.Find(NameToStats).GetComponent<Stats>();
            }
        }
    }

    void Attack() {

		
        Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
      //  EnemyStats.HP -= ((Atk * (2 ^ Level)) + Level * 550) / 2;
        Debug.Log("Torre Atacou");
      


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



}