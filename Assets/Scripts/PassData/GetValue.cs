using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValue : MonoBehaviour
{
    [SerializeField] Text myText;
    

    public void Start()
    {
        int coinValue = StaticData.ValueToKeep;
        myText.text = "You Earned " + coinValue + " Points!";
    }
}
