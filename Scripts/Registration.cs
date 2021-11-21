using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public void reg(){
    	GameObject inputFieldGo = GameObject.Find("login");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string login = inputFieldCo.text;

        inputFieldGo = GameObject.Find("FIO");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string FIO = inputFieldCo.text;

        inputFieldGo = GameObject.Find("place");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string place = inputFieldCo.text;

        inputFieldGo = GameObject.Find("password");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();
        string password = inputFieldCo.text;

        if(!(MyDataBase.check($"SELECT * FROM user WHERE FIO = '{FIO}';"))){
        	MyDataBase.ExecuteQueryWithAnswer($"INSERT INTO user (user_id, login, FIO, place, password) VALUES({MyDataBase.getlast() + 1}, '{login}', '{FIO}', '{place}', '{password}')");
        	UiEvents.exit();
        }else{
	        inputFieldGo = GameObject.Find("login");
	        inputFieldCo = inputFieldGo.GetComponent<InputField>();
	        inputFieldCo.text = "";

	        inputFieldGo = GameObject.Find("FIO");
	        inputFieldCo = inputFieldGo.GetComponent<InputField>();
	        inputFieldCo.text = "";

	        inputFieldGo = GameObject.Find("place");
	        inputFieldCo = inputFieldGo.GetComponent<InputField>();
	        inputFieldCo.text = "";

	        inputFieldGo = GameObject.Find("password");
	        inputFieldCo = inputFieldGo.GetComponent<InputField>();
	        inputFieldCo.text = "";
        }
    }
}
