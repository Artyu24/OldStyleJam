using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Update()
    {
        printValue();
    }

    // Update is called once per frame
    public void printValue()
    {
        score.text = (score.text.Replace(score.text,(string.Format("{0:N2}", (int)GameManager.instance.score)).Substring(0,(string.Format("{0:N2}", (int)GameManager.instance.score)).Length - 3)));


    }
}
