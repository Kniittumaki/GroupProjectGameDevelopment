using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   [SerializeField] private Image _img;
   [SerializeField] private Sprite _default, _pressed;
   [SerializeField] private AudioClip _compressClip, _uncompressClip;
   [SerializeField] private AudioSource _source;
    public int elamatNyt = 3;

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", elamatNyt);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

   
}
