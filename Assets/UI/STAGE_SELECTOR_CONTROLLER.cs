using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class STAGE_SELECTOR_CONTROLLER : MonoBehaviour
{
    private string scene_path = ".\\Assets\\Scenes";
    private string[] level_array = {"EASY","NORMAL","HARD","EXPERT","MASTER"};
    public UIDocument uIDocument = null;
    private VisualElement root;
    private Button button;

    private List<VisualElement> level_wrapper_array = new List<VisualElement>();
    private List<Button> button_list = new List<Button>();
    void Start()
    {
        this.root = this.uIDocument.rootVisualElement;
        
        
        

        root.Query<Button>("easy_button").ForEach((Button ele) => {
            button_list.Add(ele);
        });

        this.button = this.root.Query<Button>();
        this.button.clickable.clicked += () => {
            Debug.Log("Button clicked");
        };
        int i =0 ;
        root.Query<VisualElement>("level_wrapper").ForEach((VisualElement ele) => {
            this.level_wrapper_array.Add(ele);
            //ele.Query<Button>().ForEach((Button button) => {
            //    this.button_list.Add(button);
            //    button.clickable.clicked += () => {
            //        select_stage(button.text);
            //    };
            //});
            string[] stage_array = System.IO.Directory.GetFiles(this.scene_path+"/"+ this.level_array[i] ,"*.unity",System.IO.SearchOption.AllDirectories);
            //Debug.Log(stage_array[0]);
            foreach(string stage in stage_array){
                //stageのファイル構造の最後のファイル名をstage_nameに代入
                string stage_name = stage.Split('\\','.')[stage.Split('\\','.').Length-2];
                Button button = new Button();
                button.name = this.level_array[i]+"_button";
                button.text = stage_name;
                button.clickable.clicked += () => {
                    Debug.Log("Button clicked");
                    SceneManager.LoadScene(stage_name);
                };
                ele.Add(button);
                Debug.Log(stage_name);
            }
            i++;
        });
        Debug.Log(this.level_wrapper_array.Count);
        
        Debug.Log(this.button_list.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void return_to_title()
    {
        Debug.Log("return to title");
    }

    void select_stage(string stage_name)
    {
        Debug.Log(stage_name);
    }
}
