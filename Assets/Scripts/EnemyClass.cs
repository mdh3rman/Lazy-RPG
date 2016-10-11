using UnityEngine;
using System.Collections;

public class EnemyClass : MonoBehaviour {

    public float health = 100f;

	// Use this for initialization
	void Start () {
        PopupTextController.Initialize();
        Debug.Log(gameObject.name + " spawned with " + health + " hp.");
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(health<=0)
        {
            Destroy(gameObject);
            SpawnEnemy.DecreaseSpawnedEnemies();
            PlayerController.EnemyIsDead();
            Debug.Log(gameObject.name + " is dead.");
        }
	}

    public void Damage(float damage)
    {
        PopupTextController.CreateFloatingText(damage.ToString(), transform);
        Debug.Log(gameObject.name + " received " + damage + " damage.");
        health -= damage;
    }
}
