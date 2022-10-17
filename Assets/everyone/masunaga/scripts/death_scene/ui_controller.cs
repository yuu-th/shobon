using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui_controller : MonoBehaviour
{
    public GameObject text_object = null;
    int player_score = 5;
    string stage_name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = text_object.GetComponent<Text>();
        score_text.text = "Å~     " + player_score;
        Invoke("retry", 3);
    }

    void retry()
    {
        stage_name = PlayerController.stage_name;
        SceneManager.LoadScene(stage_name);
    }
}
