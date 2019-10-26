using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour {

    #region Variaveis
    [SerializeField] bool ToPrintConsole;
    [SerializeField] State CurrentState;
    [SerializeField] State GameOverState;

    State LastState;

    [SerializeField] Text TextTitle;
    [SerializeField] Text TextDesc;
    [SerializeField] Text TextLocal;

    [SerializeField] Text TextHP;
    [SerializeField] Text TextDano;
    [SerializeField] Text TextAcc;
    [SerializeField] Text TextDg;
    [SerializeField] Text TextMoney;
    
    [SerializeField] Button Button1;
    [SerializeField] Button Button2;
    [SerializeField] Button Button3;
    
    public double targetTime = 555.0f;

    public Hero MainHero;
    public Monster Enemy;
    #endregion

    // Use this for initialization
    void Start () {
        Refresh();

        Button1.onClick.AddListener(delegate { ChangeState(0); });
        Button2.onClick.AddListener(delegate { ChangeState(1); });
        Button3.onClick.AddListener(delegate { ChangeState(2); });

        //Starting a new game...
        MainHero = new Hero();
        RefreshHeroText();
    }
	
	// Update is called once per frame
	void Update () {
		targetTime -= Time.deltaTime;
        TextLocal.text = targetTime.ToString();
 
        if (targetTime <= 0.0f){
            SceneManager.LoadScene("Game Over");
        }
	}

    public void Console(string text) {
        if (ToPrintConsole)
            Debug.Log(text);
    }

    public void Refresh() {
        // Console("Starting Refresh...");
        
        //Need to clear the screen and then refresh.
        //Something like ClearScreen();

        switch (CurrentState.GetStateType())
        {
            case Enums.StateType.Normal:
                //Remember to turn active the objects to appear onscreen.
                RefreshNormalState();
                break;
            case Enums.StateType.VictoryScreen:
                break;
            case Enums.StateType.Upgrade:
                break;
            case Enums.StateType.Monster:
                StartBattle();
                break;
            default:
                Console("Forgot to put Type of the State. Please restart.");
                break;
        }
    }

    #region Battle
    public void StartBattle (){
        TextTitle.text = "LUTA";
        CreateEnemy();
        PrepareBattleButtons();
        TextDesc.text = RefreshMonsterText();
    }

    public void CreateEnemy(){
        Enemy = new Monster(CurrentState.GetEnemyId());
    }

    public void PrepareBattleButtons(){
        Button1.gameObject.SetActive(true);
        Button1.GetComponentInChildren<Text>().text = "Attack";

        Button2.gameObject.SetActive(true);
        Button2.GetComponentInChildren<Text>().text = "Defend";
        
        Button3.gameObject.SetActive(true);
        Button3.GetComponentInChildren<Text>().text = "Flee";
    }
    
    public string RefreshMonsterText(){
        string EnemyInfo = "";
        EnemyInfo += "HP:" + Enemy.ActualHP.ToString() + "/" + Enemy.TotalHP.ToString();
        return EnemyInfo;
    }
    
    public void Attack(){
        Console("Using Attack");
        //Hero Damage is done here
        if(Random.Range(0,101) <= MainHero.Accuracy - Enemy.Dodge){
            Console("It's a Hit!");
            Enemy.ActualHP -= Random.Range(MainHero.MinAttack, MainHero.MaxAttack + 1);
        } else{
            Console("It's a Miss!");
        }
        checkWin();
        //Enemy Damage is done here
        if(Random.Range(0,101) <= Enemy.Accuracy - MainHero.Dodge){
            Console("It's a Hit!");
            MainHero.ActualHP -= Random.Range(Enemy.MinAttack, Enemy.MaxAttack + 1);
        } else{
            Console("It's a Miss!");
        }
        checkGameOver();
    }

    public void Special(){
        Console("Using Special");
    }

    public void Flee(){
        Console("Using Flee");
    }

    public void checkGameOver(){
        if(MainHero.ActualHP <= 0){
            Console("You lost the battle...");
            MainHero.ActualHP = MainHero.TotalHP;
            Enemy.ActualHP = 0;
            SceneManager.LoadScene("Game Over");
            Refresh();
        }
    }

    public void checkWin(){
        if(Enemy.ActualHP <= 0){
            Console("You won the battle!");
            MainHero.Money += Enemy.Money;
            CurrentState = LastState;
            Refresh();
        }
    }
    #endregion

    #region RefreshNormalState
    public void RefreshNormalState()
    {
        RefreshText();
        RefreshButtonText();
        // Console("Normal State Refreshed.");
    }

    public void RefreshText()
    {
        TextDesc.text = CurrentState.GetText();
        TextTitle.text = CurrentState.GetTitle();
        // TextLocal.text = CurrentState.GetLocal();
    }

    public void RefreshButtonText() {
        //Tem que ver primeiro quais botoes entram na tela ne...
        if(CurrentState.NextStates.Length == 1) {
            Button1.gameObject.SetActive(true);
            Button1.GetComponentInChildren<Text>().text = (string)CurrentState.Label.GetValue(0);

            Button2.gameObject.SetActive(false);

            Button3.gameObject.SetActive(false);
        } else if (CurrentState.NextStates.Length == 2) {
            Button1.gameObject.SetActive(true);
            Button1.GetComponentInChildren<Text>().text = (string)CurrentState.Label.GetValue(0);

            Button2.gameObject.SetActive(true);
            Button2.GetComponentInChildren<Text>().text = (string)CurrentState.Label.GetValue(1);

            Button3.gameObject.SetActive(false);
        } else if (CurrentState.NextStates.Length == 3) {
            Button1.gameObject.SetActive(true);
            Button1.GetComponentInChildren<Text>().text = (string)CurrentState.Label.GetValue(0);

            Button2.gameObject.SetActive(true);
            Button2.GetComponentInChildren<Text>().text = (string)CurrentState.Label.GetValue(1);
            
            Button3.gameObject.SetActive(true);
            Button3.GetComponentInChildren<Text>().text = (string)CurrentState.Label.GetValue(2);
        }
    }
    #endregion

    public void RefreshHeroText()
    {
        TextHP.text = "HP:" + MainHero.ActualHP.ToString() + "/" + MainHero.TotalHP.ToString();
        TextDano.text = "Dam:" + MainHero.MinAttack.ToString() + "-" + MainHero.MaxAttack.ToString();
        TextAcc.text = "Acc:" + MainHero.Accuracy.ToString();
        TextDg.text = "Dg:" + MainHero.Dodge.ToString();
        TextMoney.text = MainHero.Money.ToString() + "$";
    }

    public void Heal(){
        if(MainHero.Money >= MainHero.TotalHP - MainHero.ActualHP){
            MainHero.Money -= MainHero.TotalHP - MainHero.ActualHP;
            MainHero.ActualHP = MainHero.TotalHP;
            RefreshHeroText();
        }
    }

    public void ChangeState(int index) {
        switch (CurrentState.GetStateType())
        {
            case Enums.StateType.Normal:
                if(index == 2 && Button3.GetComponentInChildren<Text>().text == "Heal"){
                    Console("Healing");
                    Heal();
                } else if(index <= CurrentState.NextStates.Length) {
                    LastState = CurrentState;
                    CurrentState = CurrentState.GetNextState(index);
                    Refresh();
                }
                break;
            case Enums.StateType.VictoryScreen:
                break;
            case Enums.StateType.Upgrade:
                break;
            case Enums.StateType.Monster:
                if(index == 0){
                    Attack();
                } else if (index == 1){
                    Special();
                } else if (index == 2){
                    Flee();
                }
                RefreshHeroText();
                if(Enemy.ActualHP > 0)
                    TextDesc.text = RefreshMonsterText();
                break;
            default:
                Console("Forgot to put Type of the State. Please restart.");
                break;
        }
    }
}
