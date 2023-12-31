using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;
    public Animator LayoutAnimator;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }


    //Butonlar
    public GameObject settings_open;
    public GameObject settings_close;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public GameObject iap;
    public GameObject information;
    public GameObject intro_hand;
    public GameObject taptomove;
    public GameObject noAds;
    public GameObject shop_button;

    public void FirstTouch()
    {
      intro_hand.SetActive(false);
      taptomove.SetActive(false);
      noAds.SetActive(false);
      shop_button.SetActive(false);
      settings_open.SetActive(false);
      settings_close.SetActive(false);
      sound_on.SetActive(false);
      sound_off.SetActive(false);
      vibration_on.SetActive(false);
      vibration_off.SetActive(false);
      iap.SetActive(false);
      information.SetActive(false);
}

    public void Privacy_Policy()
    {
        Application.OpenURL("https://metehanugus.com/iletisim");
    }

    public void TermsOfUse()
    {
        Application.OpenURL("https://metehanugus.com");
    }

    //Buton Fonksiyonlari

    public void Settings_Open()
    {
        settings_open.SetActive(false);
        settings_close.SetActive(true);
        LayoutAnimator.SetTrigger("slide_in");

        if (PlayerPrefs.GetInt("Sound",1) == 1)
        {
            sound_off.SetActive(false);
            sound_on.SetActive(true);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true) ;
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_off.SetActive(false);
            vibration_on.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_off.SetActive(true);
            vibration_on.SetActive(false);
        }
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
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_Off()
    {
        sound_off.SetActive(false);
        sound_on.SetActive(true);
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On ()
    {
        vibration_on.SetActive(false);
        vibration_off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void Vibration_Off ()
    {
        vibration_off.SetActive(false);
        vibration_on.SetActive(true) ;
        PlayerPrefs.SetInt("Vibration", 1);
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
