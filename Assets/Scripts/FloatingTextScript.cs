using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FloatingTextScript : MonoBehaviour
{

    public TextMeshProUGUI dmgText;
    public Color textColor = Color.red;

public void SetText(string text)
    {
        dmgText.text = text;
    }

    public void SetColor(Color color)
    {
        textColor = color;
    }
    public void StartFloatText()
    {
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        dmgText.color = textColor;
       
        for(float i = 1f; i > 0; i -= .01f)
        {
            Color temp = dmgText.color;
            temp.a = i;
            dmgText.color = temp;
            yield return new WaitForSeconds(.01f);

        }
        //TODO set alpha script
        //dmgText.color.a = .5;
        Destroy(gameObject);
    }
}
