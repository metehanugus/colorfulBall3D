using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;


    public Animator LayoutAnimator;

    //Butonlar
    public GameObject settings_open;
    public GameObject settings_close;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public GameObject iap;
    public GameObject information;

    //Buton Fonksiyonlari

    public void Settings_Open()
    {
        settings_open.SetActive(false);
        settings_close.SetActive(true);
        LayoutAnimator.SetTrigger("slide_in");
    }

    public void Settings_Close()
    {
        settings_close.SetActive(false);
        settings_open.SetActive(true);
        LayoutAnimator.SetTrigger("slide_out");
    }

    public void Sound_On ()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
    }

    public void Sound_Off()
    {
        sound_off.SetActive(false);
        sound_on.SetActive(true);
    }

    public void Vibration_On ()
    {
        vibration_on.SetActive(false);
        vibration_off.SetActive(true);
    }

    public void Vibration_Off ()
    {
        vibration_off.SetActive(false);
        vibration_on.SetActive(true) ;
    }



    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);

            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
            {
                effectcontrol = 1;
            }
                
        
        }

        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);

            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }

        }

        if (effectcontrol == 2)
        {
            Debug.Log("Efekt Bitti");
        }
        
    }
}
