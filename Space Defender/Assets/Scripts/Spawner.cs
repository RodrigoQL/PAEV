using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject PowerUp;
    public GameObject V3;
    public GameObject VVV;
    public GameObject LittleAsteroid;
    public GameObject MediumAsteroid;
    public GameObject BigAsteroid;
    public GameObject SmallRush;
    public GameObject Boss;

    public int difficulty;

	void Start () {
        InvokeRepeating("SpawnPowerUp", 7, 12+difficulty);
        InvokeRepeating("SpawnV3", 0, 8-difficulty);
        InvokeRepeating("SpawnVVV", 25, 9-difficulty);
        InvokeRepeating("SpawnRush", 75-(difficulty*10), 10 - (difficulty*2));
        InvokeRepeating("SpawnAsteroid", 4, 10-difficulty);

        InvokeRepeating("SpawnVVV2", 125, 7 - difficulty);
        InvokeRepeating("SpawnRush2", 155 - (difficulty * 10), 10 - (difficulty * 2));
        InvokeRepeating("SpawnAsteroid2", 104, 10 - difficulty);
        InvokeRepeating("SpawnBoss", 190, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnPowerUp()
    {
        Vector3 pos = new Vector3(Random.Range(-5f,5f), 10, 1);
        Instantiate(PowerUp, pos, Quaternion.identity);
    }
    void SpawnV3()
    {
        Vector3 pos = new Vector3(Random.Range(-4f, 4f), 10, 1);
        Destroy(Instantiate(V3, pos, Quaternion.identity),20);
    }
    void SpawnBoss()
    {
        CancelInvoke("SpawnAsteroid");
        CancelInvoke("SpawnAsteroid2");
        CancelInvoke("SpawnVVV");
        Vector3 pos = new Vector3(0, 15, 1);
        Instantiate(Boss, pos, Quaternion.identity);
    }
    void SpawnVVV()
    {
        if (Random.Range(0f, 1f) > 0.4f)
        {
            Vector3 pos = new Vector3(0, 10, 1);
            Destroy(Instantiate(VVV, pos, Quaternion.identity), 20);
        }
    }
    void SpawnVVV2()
    {
        if (Random.Range(0f, 1f) > 0.4f)
        {
            Vector3 pos = new Vector3(0, 10, 1);
            Destroy(Instantiate(VVV, pos, Quaternion.identity), 20);
        }
    }
    void SpawnRush()
    {
        Vector3 pos = new Vector3(Random.Range(-4f, 4f), 10, 1);
        Destroy(Instantiate(SmallRush, pos, Quaternion.identity), 20);
    }
    void SpawnRush2()
    {
        Vector3 pos = new Vector3(Random.Range(-5f, 5f), 10, 1);
        Destroy(Instantiate(SmallRush, pos, Quaternion.identity), 20);
    }
    void SpawnAsteroid()
    {
        float r = Random.Range(0f, 1f);
        if(r>0.5)
        {
            Vector3 pos = new Vector3(Random.Range(-6f, 6f), 11, 0);
            if(r<0.75)
            {
                Instantiate(LittleAsteroid, pos, Quaternion.identity);
            }
            else if(r < 0.9)
            {
                Instantiate(MediumAsteroid, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(BigAsteroid, pos, Quaternion.identity);
            }
        }
    }
    void SpawnAsteroid2()
    {
        float r = Random.Range(0f, 1f);
        if (r > 0.25)
        {
            Vector3 pos = new Vector3(Random.Range(-6f, 6f), 11, 0);
            if (r < 0.6)
            {
                Instantiate(LittleAsteroid, pos, Quaternion.identity);
            }
            else if (r < 0.85)
            {
                Instantiate(MediumAsteroid, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(BigAsteroid, pos, Quaternion.identity);
            }
        }
    }
}
