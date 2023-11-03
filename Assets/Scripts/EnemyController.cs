using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject SceneLoader;
    [SerializeField] GameObject EnemyModel;

    [SerializeField] float time;
    [SerializeField] float DamageToPlayer;
    float timeStore;
    float EnemyPositionX;
    float PlayerPositionX;
    float EnemyPositionZ;
    float PlayerPositionZ;
    float rotationSpeed = 3.0f;
    float moveSpeed = 3.0f;

    Transform target;

    NavMeshAgent agent;
    
    [SerializeField] Slider slider;

    Animator animator;

    void Start()
    {

        Enemy = this.gameObject;

        animator = EnemyModel.GetComponent<Animator>();

    }

    void Update()
    {



        if (Math.Abs(Math.Abs(EnemyPositionX) - Math.Abs(PlayerPositionX)) <10 && Math.Abs(Math.Abs(EnemyPositionZ) - Math.Abs(PlayerPositionZ)) <10)
        {

            if (Math.Abs(Math.Abs(EnemyPositionX) - Math.Abs(PlayerPositionX)) > 0.1 && Math.Abs(Math.Abs(EnemyPositionZ) - Math.Abs(PlayerPositionZ)) > 0.1)
            {
                MoveEnemy();
                RotateEnemy();
                EnemyModel.gameObject.GetComponent<Animator>().enabled = true;
               
                
            }
           
        }
        else
        {
            EnemyModel.gameObject.GetComponent<Animator>().enabled = false;
        }

       

        EnemyPositionX = Enemy.transform.position.x;
        PlayerPositionX = Player.transform.position.x;
        EnemyPositionZ = Enemy.transform.position.z;
        PlayerPositionZ = Player.transform.position.z;

        EnemyAttack();

    }
   

    void RotateEnemy()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), rotationSpeed * Time.deltaTime);

    }

    void MoveEnemy()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void EnemyAttack()
    {

        PlayerHealth PlayerHealth = Player.GetComponent<PlayerHealth>();

        if (Math.Abs(Math.Abs(EnemyPositionX) - Math.Abs(PlayerPositionX)) < 2 && Math.Abs(Math.Abs(EnemyPositionZ) - Math.Abs(PlayerPositionZ)) < 2 )
        {
                PlayerHealth.health -= DamageToPlayer;
                slider.value = PlayerHealth.health;
                animator.SetBool("isPunching", true);
                if (slider.value == 0)
                {
                    SceneLoader.GetComponent<Death>().DeathFunction("The enemy beat ya!");
                }
                
        }
        else
        {
            animator.SetBool("isPunching", false);
        }
    }
}
