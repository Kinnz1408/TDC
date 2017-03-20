using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// ESSE FUNCIONA FILHO DA PUTA !!!!!!!!!!!!!
public class Navmesh : MonoBehaviour
{
   public Transform target;
    NavMeshAgent agent;
    public bool CheckNav;
    public GameObject NameEnemy;
    public string FinalDestinationName;
    GameObject FinalDestinationObject;
    public string TagToChase;
    // Use this for initialization
    void Start()
    {
    
    agent = GetComponent<NavMeshAgent>();

        FinalDestinationObject = GameObject.Find(FinalDestinationName);
        target = FinalDestinationObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!this.target)
        {
            
            target = FinalDestinationObject.transform;
            Debug.Log("Objeto está vazio");

        }

        agent.SetDestination(target.position);

    //    Debug.Log(target);


      
        //    target = gameObject.transform.Find(NameEnemy);
            

        
        //Check se o slot de target tá vazio .
      

    }


   void OnTriggerEnter(Collider collision)
    {
        {
            if (collision.gameObject.tag == TagToChase)
            {
             //   string contact = collision.transform.name;
                string contact2 = collision.gameObject.name;
                NameEnemy = GameObject.Find(contact2);
                target = this.NameEnemy.transform;
                Debug.Log(contact2);
            }
        }
}





}
