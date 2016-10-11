using UnityEngine;
using System.Collections;


public class AttackTrigger : MonoBehaviour {

    private float damage;
    private PlayerController player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

	void OnTriggerEnter2D (Collider2D col)
    {
        if(col.name.StartsWith("en"))
        {
            damage = player.STR.StatValue;
            col.SendMessageUpwards("Damage", damage);
        }
    }


}
