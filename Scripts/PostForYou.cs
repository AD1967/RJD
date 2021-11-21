using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
public class PostForYou : MonoBehaviour
{
    void Update()
    {
    	var tx = GameObject.Find("Text");
    	var tx1 = tx.GetComponent<Text>();
    	tx1.text = "";
    	DataTable t = MyDataBase.GetTable($"SELECT * FROM post WHERE Получатель = '{ScoreManager.FIO}';");
       	string FIO = "", ID = "";
       	string pat = "";
       	for(int i = 0; i < t.Rows.Count; i++){
       		FIO = t.Rows[i][1].ToString();
       		ID = t.Rows[i][0].ToString();
       		pat = $"{i + 1}) ID:{ID} От кого: {FIO};";
       		tx1.text += pat + "\n";
       	}
    }

    public void del_inf(){
    	GameObject inputFieldGo = GameObject.Find("inf");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string idinf = inputFieldCo.text;

        if(MyDataBase.check($"SELECT * FROM post WHERE Получатель = '{ScoreManager.FIO}' AND id = '{idinf}';")){
        	MyDataBase.ExecuteQueryWithoutAnswer($"DELETE FROM post WHERE id = '{idinf}';");
        }else{
        	inputFieldCo.text = "";
        }
    }
}
