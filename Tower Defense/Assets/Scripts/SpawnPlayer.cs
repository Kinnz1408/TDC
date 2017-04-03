using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour {

    // Fazer Array para os Enemys
    public Transform enemyPrefab;
    public Transform enemyPrefab02;
    public Transform enemyPrefab03;



    public float timeBetweenWaves;
    public float countdown;
    public int [] WaveNumer;
    public Transform SpawnPoint;
    int NameCount;
    public bool ButtonOn;
    Ui MyUI;
    public int MinValueToSpawn;
    public int[] SpawnWaveCust;







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
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        enemyPrefab.name = "EnemyA" + NameCount;

    }
    public void Spawn1() {
        NameCount++;
        Instantiate(enemyPrefab02, SpawnPoint.position, SpawnPoint.rotation);
        enemyPrefab.name = "EnemyB" + NameCount;
    }
    public void Spawn2()
    {
        Instantiate(enemyPrefab03, SpawnPoint.position, SpawnPoint.rotation);
        enemyPrefab.name = "EnemyC" + NameCount;
        ButtonOn = false;
    }
    IEnumerator SpawnWave()
    {         
        for (int i = 0; i < WaveNumer[0]; i++)
        {
            Spawn();
            yield return new WaitForSeconds(1f);
        }
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

}
