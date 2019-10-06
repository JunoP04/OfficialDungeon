using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Create TD Object/Enemy", order = 0)]
public class newEnemy : ScriptableObject
{

    public List<enemyData> inventory;

}


public class enemyData : ScriptableObject
{

    public string enemyName;
    public int enemyHealth;
    public int movementSpeed;
    public int level;
}

public class playerData : ScriptableObject
{

    public string playerName;
    public int playerHealth;
    public int movementSpeed;
    public int level;
}