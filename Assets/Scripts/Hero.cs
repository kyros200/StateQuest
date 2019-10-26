using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero{

    public int ActualHP { get; set; }
    public int TotalHP { get; set; }
    public int MinAttack { get; set; }
    public int MaxAttack { get; set; }
    public int Accuracy { get; set; }
    public int Dodge { get; set; }
    public int Flee { get; set; }
    public int Money { get; set; }

    public Hero()
    {
        ActualHP = 10;
        TotalHP = 10;
        MinAttack = 1;
        MaxAttack = 3;
        Accuracy = 80;
        Flee = 80;
        Dodge = 15;
        Money = 0;
    }

    public Hero(int totalHP, int minAttack, int maxAttack, int accuracy, int flee, int dodge, int money)
    {
        ActualHP = totalHP;
        TotalHP = totalHP;
        MinAttack = minAttack;
        MaxAttack = maxAttack;
        Accuracy = accuracy;
        Flee = flee;
        Dodge = dodge;
        Money = money;
    }
}
