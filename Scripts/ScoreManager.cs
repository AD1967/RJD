using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static string FIO = "";
    public void do_some()
    {

        GameObject inputFieldGo = GameObject.Find("login");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        GameObject inputFieldGo1 = GameObject.Find("password");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
        string login = inputFieldCo.text;
        string password = inputFieldCo1.text;
        string user_password = MyDataBase.ExecuteQueryWithAnswer($"SELECT password FROM user WHERE login = '{login}';");

        if(user_password == password){
            FIO = MyDataBase.ExecuteQueryWithAnswer($"SELECT FIO FROM user WHERE login = '{login}';");
            SceneManager.LoadScene("Work");
        }else{
            Debug.Log("Пароль неверный");
            inputFieldCo.text = "";
            inputFieldCo1.text = "";
        }
    }
}