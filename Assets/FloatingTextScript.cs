using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FloatingTextScript : MonoBehaviour
{

    public TextMeshProUGUI dmgText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fade());
    }
public void setText(string text)
    {
        dmgText.text = text;
    }

    IEnumerator fade()
    {
        

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
