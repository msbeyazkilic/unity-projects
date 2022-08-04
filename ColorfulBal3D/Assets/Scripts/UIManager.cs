using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject whiteEffectImage;
    private int effectControl = 0;
    public IEnumerator WhiteEffect()
    {

        whiteEffectImage.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.GetComponent<Image>().color += new Color(0,0,0, 0.1f);
            Debug.Log("effectControl == 0 " +whiteEffectImage.GetComponent<Image>().color.a);
            if (whiteEffectImage.GetComponent<Image>().color.a >  1.0f)
            {
                effectControl = 1;
            }

        }

        while (effectControl == 1 )
        {
            yield return new WaitForSeconds(0.01f);
            whiteEffectImage.GetComponent<Image>().color -= new Color(0, 0, 0, 0.1f);
            Debug.Log("effectControl == 1 " + whiteEffectImage.GetComponent<Image>().color.a);
            if (whiteEffectImage.GetComponent<Image>().color.a < 0.0f)
            {
                effectControl = 2;
            }

        }


    }
}
