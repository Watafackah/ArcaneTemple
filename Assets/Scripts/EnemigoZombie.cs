using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoZombie : MonoBehaviour
{
    public int Vida = 100;//vida enemigo
    public Animator anim;

    public NavMeshAgent nav;
    public Transform player;//poner objeto al que sigue el enemigo

    //public int vidaPlayer;//script vida del player
    //public int ataque;//vida que saca el enemigo al player al atacar
    public bool AtacBool;
    public CharacterController character;
    public Rigidbody rgb;

    public float distancia; //distancia que hay entre el player y el enemigo

    public bool muerte;

    private void Start()
    {
        character.enabled = true;
        AtacBool = false;
        player =  GameObject.FindWithTag("Player").transform;


    }
    private void Update()
    {
        //CALCULAR DISTANCIA
        distancia = Vector3.Distance(transform.position, player.position);
        transform.LookAt(player);

        //SEGUIR AL PLAYER
        /* if (Vida >= 1)
         {// si la vida del enemigo es mayor de 1, el enemigo seguira al player
             nav.destination = player.position;
         }*/
        if (Vida >= 0)
        {
            if (distancia < 4)
            {// si distancia es mas grande de 3
                nav.speed = 0.2f;
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", false);
            }
            if (distancia > 4 && distancia < 10)
            {// si distancia es mas grande de 3
                nav.speed = 3;
                anim.SetBool("Attack", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Run", true);
            }
            if (distancia > 11)
            {// si distancia es mas grande de 3
                nav.speed = 10;
                anim.SetBool("Attack", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }

            if (nav.speed <= 0.1f)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);
            }
        }
        else
        {
            anim.SetBool("FallingBack", true);
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            character.enabled = false;
            nav.speed = 0f;
            Invoke("Muerto", 2);//tiempo que tarda en desaparecer una vez a llegado su vida a 0

        }

        //ATAQUE
        /*  if (distancia < nav.stoppingDistance && AtacBool == false)
          {
              nav.speed = 0;
              anim.SetBool("Attack", true);

              Invoke("Attack", 1.1f);//tiempo que tarda en dar el golpe
              AtacBool = true;
          }*/

        //VIDA

    }

    void Muerto()
    {
        // //Opcion1
        
        //Destroy(gameObject,2f);
        gameObject.SetActive(false);  //Opcion2
    }

    void AF()
    {
        AtacBool = false;
    }

    void FV(int Dano)
    {
        Vida -= Dano;
    }
}
