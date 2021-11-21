using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
public class CurrentPost : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {	
  		
    }
    // Update is called once per frame
    void Update()
    {
    	var tx = GameObject.Find("Text");
    	var tx1 = tx.GetComponent<Text>();
    	tx1.text = "";
    	DataTable t = MyDataBase.GetTable($"SELECT * FROM post WHERE Отправитель = '{ScoreManager.FIO}';");
       	string FIO = "", place = "", ID = "";
       	string pat = "";
       	for(int i = 0; i < t.Rows.Count; i++){
       		FIO = t.Rows[i][2].ToString();
       		ID = t.Rows[i][0].ToString();
       		place = MyDataBase.ExecuteQueryWithAnswer($"SELECT place FROM user WHERE FIO = '{FIO}';");
       		pat = $"{i + 1}) ID:{ID} Кому: {FIO}; Куда: {place}";
       		tx1.text += pat + "\n";
       	}
    }

    public void find_inf(){
    	GameObject inputFieldGo = GameObject.Find("inf");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string idinf = inputFieldCo.text;

        if(MyDataBase.check($"SELECT * FROM post WHERE Отправитель = '{ScoreManager.FIO}' AND id = '{idinf}';")){
        	var tx = GameObject.Find("Text2");
    		var tx1 = tx.GetComponent<Text>();
    		tx1.text = MyDataBase.ExecuteQueryWithAnswer($"SELECT Последнее FROM post WHERE id = '{idinf}';");
        }else{
        	inputFieldCo.text = "";
        }
    }
}
