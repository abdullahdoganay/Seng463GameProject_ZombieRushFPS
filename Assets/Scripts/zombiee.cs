using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombiee : MonoBehaviour
{
    Animation animation;
    ZombieHealth zombieHealth;

    // Start is called before the first frame update
    void Start()
    {
        zombieHealth = GetComponent<ZombieHealth>();

        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHealth.GetHealth() <= 0)
        {
            animation.Play("Death");

        }

        //switch (zombieState)
        //{
        //    case ZombieState.Dead:
        //        KillZombie();
        //        break;
        //    case ZombieState.Attack:
        //        Attack();
        //        break;
        //    case ZombieState.Walk:
        //        SearchForTarget();
        //        break;
        //    case ZombieState.Idle:
        //        SearchForTarget();
        //        break;
        //    default:
        //        break;
        //}
    }
}
