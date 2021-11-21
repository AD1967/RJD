using System.Collections;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiEvents : MonoBehaviour
{
    public void sign_in(){
        SceneManager.LoadScene("Get In");
    }

    public void sign_up(){
        SceneManager.LoadScene("Sign Up");
    }

    public static void exit(){
        SceneManager.LoadScene("Menu");
    }
    public static void ex1t(){
        SceneManager.LoadScene("Work");
    }
    public static void s2(){
    	SceneManager.LoadScene("MailForYou");
    }
    public static void s1(){
    	SceneManager.LoadScene("CurrentMail");
    }
    public static void s3(){
    	SceneManager.LoadScene("MailForYou");
    }
    public static void s4(){
        SceneManager.LoadScene("Build");
    }
}