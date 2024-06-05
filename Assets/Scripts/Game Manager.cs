using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text title;
    public Button playButton;
    public bool isGameOn;
    // Start is called before the first frame update
    void Start()
    {
        isGameOn = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOn = true)
        {
            //turn off button and title
            //start game sound and effects
            //turn off cool game background
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Assembly");
        isGameOn =  true;
    }
}
