using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject myCharacter;
    public Transform SpawnPoint;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    int numero;

    // This script will be added to any multiplayer scene
    void Start()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
    }
    void CreatePlayer()
    {
        Debug.Log("Creating Player");

        numero = Random.Range(1, 4);


        switch (numero)
        {
            case 1:
                myCharacter = Instantiate(myCharacter, SpawnPoint.position, Quaternion.identity) as GameObject;
                break;
            case 2:
                myCharacter = Instantiate(myCharacter, SpawnPoint1.position, Quaternion.identity) as GameObject;
                break;
            case 3:
                myCharacter = Instantiate(myCharacter, SpawnPoint2.position, Quaternion.identity) as GameObject;
                break;
            case 4:
                myCharacter = Instantiate(myCharacter, SpawnPoint3.position, Quaternion.identity) as GameObject;
                break;
        }  
    }
}
