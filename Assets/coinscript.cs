using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinscript : MonoBehaviour
{
    public int coincount;
    public Text score;
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            collision.gameObject.SetActive(false);
            coincount++;
            score.text = coincount.ToString();

        }
    }
}
