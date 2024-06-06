using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        set; get;
    }
    public TMP_Text title;
     public Button playButton;
    public bool isGameOn;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isGameOn = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOn == true)
        {
            //turn off button and title
            title.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            PlayerMovement.Instance.jumpButton.gameObject.SetActive(true);
            PlayerMovement.Instance.joystick.gameObject.SetActive(true);
            //start game sound and effects
            //turn off cool game background
        }
    }

    public void Play()
    {
        isGameOn =  true;
    }
}
