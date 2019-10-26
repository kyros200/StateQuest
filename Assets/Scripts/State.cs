using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "State", order = 1)]
public class State : ScriptableObject{
    
    [SerializeField] public State[] NextStates;
    [SerializeField] public string[] Label;
    [SerializeField] string Text;
    [SerializeField] string Title;
    [SerializeField] string Local;
    [SerializeField] Enums.StateType Type;
    [SerializeField] int EnemyId;

    public string GetText()
    {
        return Text;
    }

    public string GetTitle()
    {
        return Title;
    }

    public string GetLocal()
    {
        return Local;
    }

    public string[] GetLabel()
    {
        return Label;
    }

    public Enums.StateType GetStateType()
    {
        return Type;
    }

    public State GetNextState(int index) {
        return (State)NextStates.GetValue(index);
    }

    public int GetEnemyId(){
        return EnemyId;
    }
}
