using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
public class findway : MonoBehaviour
{
    public void find(){
    	GameObject inputFieldGo = GameObject.Find("from");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string from1 = inputFieldCo.text;

        GameObject inputFieldGo1 = GameObject.Find("to");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
        string to1 = inputFieldCo1.text;

        var tx = GameObject.Find("Text1");
    	var tx1 = tx.GetComponent<Text>();
    	tx1.text = "";
    	Debug.Log(from1);
    	DataTable t = MyDataBase.GetTable($"SELECT * FROM route WHERE from1 = '{from1}' AND to1 = '{to1}' ORDER BY time1;");
       	string time = "", id = "";
       	string pat = "";
       	for(int i = 0; i < t.Rows.Count; i++){
       		Debug.Log(1);
       		time = t.Rows[i][3].ToString();
       		id = t.Rows[i][0].ToString();
       		pat = $"{i + 1}) ID:{id} От куда: {from1}; Куда: {to1}; Время отправки: {time}";
       		tx1.text += pat + "\n";
       	}
    }
    public void sent(){
    	GameObject inputFieldGo0 = GameObject.Find("for");
        InputField inputFieldCo0 = inputFieldGo0.GetComponent<InputField>();
        string for1 = inputFieldCo0.text;

        GameObject inputFieldGo = GameObject.Find("from");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string from1 = inputFieldCo.text;

        GameObject inputFieldGo1 = GameObject.Find("to");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
        string to1 = inputFieldCo1.text;

        GameObject inputFieldGo3 = GameObject.Find("id");
        InputField inputFieldCo3 = inputFieldGo3.GetComponent<InputField>();
        string id1 = inputFieldCo3.text;

        GameObject type = GameObject.Find("Dropdown");
        Dropdown t = type.GetComponent<Dropdown>();
        string ot = ScoreManager.FIO;
        string train = MyDataBase.ExecuteQueryWithAnswer($"SELECT train FROM route WHERE id = '{id1}';");
        int type1 = (t.options[t.value].text == "Посылка") ? 1 : 0;
        MyDataBase.ExecuteQueryWithoutAnswer($"INSERT INTO post (id, Отправитель, Получатель, Последнее, Тип, Поезд) VALUES({id1}, '{ot}', '{for1}', '{from1}', '{type1}','{train}')");

        UiEvents.ex1t();
    }
}
