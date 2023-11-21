using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List <Transform> Enemy_Spawner_List;
    public Transform SpawnLocation;
    public GameObject Zombie,Zombie2,Zombie3,Zombie4,Zombie5;
    public float respawn_time;
    
    void Awake (){
        SpawnLocation = Enemy_Spawner_List[Random.Range(0,Enemy_Spawner_List.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        respawn_time -= Time.deltaTime;
        if (respawn_time <= 0)
        {
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        int i = Random.Range(1,4);

        switch (i)
        {
            case 1 : 
                   GameObject zombie_respawn = Instantiate(Zombie,SpawnLocation.position, SpawnLocation.rotation);
                   Rigidbody2D zombie_sp = zombie_respawn.GetComponent<Rigidbody2D>();
                   break;
            case 2 : 
                   GameObject zombie_respawn_1 = Instantiate(Zombie2,SpawnLocation.position, SpawnLocation.rotation);
                   Rigidbody2D zombie_sp_1 = zombie_respawn_1.GetComponent<Rigidbody2D>();
                   break;
            case 3 : 
                   GameObject zombie_respawn_2 = Instantiate(Zombie3,SpawnLocation.position, SpawnLocation.rotation);
                   Rigidbody2D zombie_sp_2 = zombie_respawn_2.GetComponent<Rigidbody2D>();
                   break;
            case 4 : 
                   GameObject zombie_respawn_3 = Instantiate(Zombie4,SpawnLocation.position, SpawnLocation.rotation);
                   Rigidbody2D zombie_sp_3 = zombie_respawn_3.GetComponent<Rigidbody2D>();
                   break;
            case 5 : 
                   GameObject zombie_respawn_4 = Instantiate(Zombie5,SpawnLocation.position, SpawnLocation.rotation);
                   Rigidbody2D zombie_sp_4 = zombie_respawn_4.GetComponent<Rigidbody2D>();
                   break;
        }
        respawn_time = Random.Range(2, 5);
        SpawnLocation = Enemy_Spawner_List[Random.Range(0, Enemy_Spawner_List.Count)];                    
                    
    }
    
}
