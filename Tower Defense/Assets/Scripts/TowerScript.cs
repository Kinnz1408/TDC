using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {
	private Transform target;
	private string NameToStats;
	private bool AttackEnable;
	public bool CheckNav;
	public GameObject NameEnemy;
	//public string FinalDestinationName;
	//GameObject FinalDestinationObject;
	public string TagToChase;
	public float TimeBetweenAttack;
	private float ResetTimetoAttack;
	private Stats EnemyStats;
    public Transform PauseCanvas;





    // Status Torre

    public int Level;
	public int HP;
	public int Atk;





	// Use this for initialization
	void Start () {
		AttackEnable = false;
		ResetTimetoAttack = TimeBetweenAttack;
		//FinalDestinationObject = GameObject.Find(FinalDestinationName);
		//target = FinalDestinationObject.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
				Debug.Log(contact2);
				EnemyStats=GameObject.Find(NameToStats).GetComponent<Stats>();
			}
		}
	}

	void Attack() {

		EnemyStats.HP -= ((Atk*(2^Level)) +Level*550) /2;   


	}
    public void Pause()
    {
        if (PauseCanvas.gameObject.activeInHierarchy == false)
        {

            PauseCanvas.gameObject.SetActive(true);
           
            
        }
        else
        {
            PauseCanvas.gameObject.SetActive(false);
            
           
        }

    }
    void OnMouseDown()
    {
        Pause();
    }



}