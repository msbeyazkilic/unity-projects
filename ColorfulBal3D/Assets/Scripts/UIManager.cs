using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject whiteEffectImage;
    public IEnumerator WhiteEffect()
    {

        whiteEffectImage.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            whiteEffectImage.GetComponent<Image>().color += new Color(0,0,0, 0.1f);
            if (whiteEffectImage.GetComponent<Image>().color.a == 1f)
            {

            }

        }

    }
}
