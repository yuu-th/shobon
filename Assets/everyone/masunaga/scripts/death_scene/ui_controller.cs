using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui_controller : MonoBehaviour
{
    public GameObject text_object = null;
    private int life;
    string stage_name;
    void Start()
    {
        this.life = PlayerPrefs.GetInt("LIFE")-1;
        PlayerPrefs.SetInt("LIFE", life);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = text_object.GetComponent<Text>();
        score_text.text = "�~     " + life;
        Invoke("retry", 3);
    }

    void retry()
    {
        stage_name = PlayerController.stage_name;
        SceneManager.LoadScene(stage_name);
    }
}
