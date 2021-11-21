using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class name : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var tx = GameObject.Find("name");
    	var tx1 = tx.GetComponent<Text>();
    	tx1.text = ScoreManager.FIO;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
