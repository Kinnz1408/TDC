using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : MonoBehaviour {
    [HideInInspector] private Transform target;
    [HideInInspector] private string targetName;
    [SerializeField] float spd;
    [HideInInspector]    [SerializeField] float rayCastOffset;
    [SerializeField] float rotationalDamp;
    [HideInInspector] [SerializeField] float detectionDistance;
    TowerScript thisTower;
    [HideInInspector] public string TowerName;
    Stats stats;



    // Update is called once per frame
     void Start()
    {
        thisTower = GameObject.Find(TowerName).GetComponent<TowerScript>();
        target = thisTower.NameEnemy.transform;
        targetName = target.gameObject.name;
    }
    void Update () {

        if (target != null) {
            PathFinder();
            Move();
        } 
        else Destroy(gameObject);        
	}
    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);

    }
    void Move()
    {
        transform.position += transform.forward * spd * Time.deltaTime;

    }
    void PathFinder() {

        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right*rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward*detectionDistance, Color.yellow);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.yellow);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.yellow);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.yellow);


        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance)) 
            raycastOffset += Vector3.right;
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
            raycastOffset -= Vector3.right;

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
            raycastOffset -= Vector3.up;
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
            raycastOffset += Vector3.up;

        if (raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * 5 * Time.deltaTime);
        else
            Turn();





    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == targetName) {
           
            stats = GameObject.Find(col.gameObject.name).GetComponent<Stats>();
            stats.HP -= ((thisTower.Atk * (2 ^ thisTower.Level)) + thisTower.Level * 550) / 2;
            Debug.Log(stats.HP);
            Destroy(gameObject);
        }
        
    }


}
