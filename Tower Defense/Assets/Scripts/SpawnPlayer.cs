using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour {

    // Fazer Array para os Enemys
    public Transform[] enemyPrefab;
    public float timeBetweenWaves;
    public float countdown;
    public int [] WaveNumer;
    public Transform SpawnPoint;
    public Transform[] SpawnPosition;
    int NameCount;
    public bool ButtonOn;
    Ui MyUI;
    public int MinValueToSpawn;
    public int[] SpawnWaveCust;
    public bool isSpawning;
    public float timeBetweenEnemies;
    public string FinalDestination;
    
    
    
    // Use this for initialization
    void Start() {
        GameObject UiManager = GameObject.Find("Ui");
        MyUI = UiManager.GetComponent<Ui>();
        

        
    }
    // Update is called once per frame
    void Update() {
        countdown -= Time.deltaTime;
    }
    public void SetButtonOn()
    {
        ButtonOn = true;
    }
    public void SpawnAlly01() {
        if (countdown <= 0 && ButtonOn == true && MyUI.Gold > MinValueToSpawn + SpawnWaveCust[0])
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            ButtonOn = false;
            MyUI.Gold -= MinValueToSpawn + SpawnWaveCust[0];
        }
    }
    public void SpawnAlly02() {
        if (countdown <= 0 && ButtonOn == true && MyUI.Gold > MinValueToSpawn + SpawnWaveCust[1])
        {
            StartCoroutine(SpawnWave1());
            countdown = timeBetweenWaves;
            ButtonOn = false;
            MyUI.Gold -= MinValueToSpawn + SpawnWaveCust[1];
        }
    }
    public void SpawnAlly03() {
        if (countdown <= 0 && ButtonOn == true && MyUI.Gold > MinValueToSpawn + SpawnWaveCust[2])
        {
            countdown = timeBetweenWaves;
            NameCount++;        
            MyUI.Gold -= MinValueToSpawn + SpawnWaveCust[2];
        }
    }
    public void Spawn(){
        NameCount++;
        Instantiate(enemyPrefab[0], SpawnPoint.position +new Vector3(1,0,0) , SpawnPoint.rotation);
        enemyPrefab[0].name = "EnemyA" + NameCount;
    }
    public void Spawn1() {
        NameCount++;
        Instantiate(enemyPrefab[1], SpawnPoint.position, SpawnPoint.rotation);
        enemyPrefab[1].name = "EnemyB" + NameCount;
    }
    public void Spawn2()
    {
        Instantiate(enemyPrefab[2], SpawnPoint.position, SpawnPoint.rotation);
        enemyPrefab[2].name = "EnemyC" + NameCount;
        ButtonOn = false;
    }
    IEnumerator SpawnWave()
    {         
        for (int i = 0; i < WaveNumer[0]; i++)
        {
            isSpawning = true;
            Spawn();
            if (i == WaveNumer[0] - 1) {
                timeBetweenEnemies = 0;
            }
            yield return new WaitForSeconds(timeBetweenEnemies);
            
        }
        isSpawning = false;
        timeBetweenEnemies = 1;

    }
    IEnumerator SpawnWave1()
    {
        for (int i = 0; i < WaveNumer[1]; i++)
        {
            Spawn1();
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator SpawnWave2()
    {
        for (int i = 0; i < WaveNumer[2]; i++)
        {
            Spawn2();
            yield return new WaitForSeconds(1f);
        }
    }

    public void ChangeSpawnPosition() {
        if (MyUI.towerCanvas1.gameObject.activeInHierarchy == true && isSpawning == false) {
            FinalDestination = "TowerA (1)";
            SpawnPoint = SpawnPosition[1];
           






        }
        if (MyUI.towerCanvas.gameObject.activeInHierarchy == true && isSpawning == false) {
            FinalDestination = "TowerA";
            SpawnPoint = SpawnPosition[0];

        }





    }

}
