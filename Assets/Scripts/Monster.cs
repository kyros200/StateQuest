using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster{

    public int ActualHP { get; set; }
    public int TotalHP { get; set; }
    public int MinAttack { get; set; }
    public int MaxAttack { get; set; }
    public int Accuracy { get; set; }
    public int Dodge { get; set; }
    public int Money { get; set; }

    public Monster()
    {
        ActualHP = 3;
        TotalHP = 3;
        MinAttack = 1;
        MaxAttack = 1;
        Accuracy = 80;
        Dodge = 0;
        Money = 5;
    }

    public Monster(int id)
    {
        if(id == 1){
            ActualHP = 3;
            TotalHP = 3;
            MinAttack = 1;
            MaxAttack = 1;
            Accuracy = 80;
            Dodge = 0;
            Money = 5;
        }
        if(id == 2){
            ActualHP = 5;
            TotalHP = 5;
            MinAttack = 3;
            MaxAttack = 5;
            Accuracy = 80;
            Dodge = 20;
            Money = 10;
        }
        if(id == 3){
            ActualHP = 8;
            TotalHP = 8;
            MinAttack = 5;
            MaxAttack = 10;
            Accuracy = 80;
            Dodge = 30;
            Money = 25;
        }
        if(id == 4){
            ActualHP = 15;
            TotalHP = 15;
            MinAttack = 8;
            MaxAttack = 15;
            Accuracy = 80;
            Dodge = 40;
            Money = 60;
        }
        if(id == 5){
            ActualHP = 20;
            TotalHP = 20;
            MinAttack = 15;
            MaxAttack = 15;
            Accuracy = 80;
            Dodge = 50;
            Money = 150;
        }
        if(id == 6){
            ActualHP = 35;
            TotalHP = 35;
            MinAttack = 1;
            MaxAttack = 60;
            Accuracy = 150;
            Dodge = 60;
            Money = 0;
        }
    }

    public Monster(int totalHP, int minAttack, int maxAttack, int accuracy, int dodge, int money)
    {
        ActualHP = totalHP;
        TotalHP = totalHP;
        MinAttack = minAttack;
        MaxAttack = maxAttack;
        Accuracy = accuracy;
        Dodge = dodge;
        Money = money;
    }
}
