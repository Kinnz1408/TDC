
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized*speed*Time.deltaTime,Space.World);
        //Transformar essa variável em pública!!!!!!
        if (Vector3.Distance(transform.position,target.position) <= 0.4f) {

            GetNextWayPoint();
        }

        
    }
    void GetNextWayPoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
