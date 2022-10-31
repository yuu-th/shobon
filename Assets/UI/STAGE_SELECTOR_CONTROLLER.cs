using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class STAGE_SELECTOR_CONTROLLER : MonoBehaviour
{
    public List<List<int>> Data;
    public GameObject back_stage;
    private string scene_path = "./Assets/Scenes";
    private string[] level_path_array = {"STAGE_EASY","STAGE_NORMAL","STAGE_HARD","STAGE_EXPERT","STAGE_MASTER"};
    private string[] level_array = {"EASY","NORMAL","HARD","EXPERT","MASTER"};
    public UIDocument uIDocument = null;
    private VisualElement root;
    private Button button;

    private List<VisualElement> level_wrapper_array = new List<VisualElement>();
    void Start()
    {
        Debug.Log(Application.persistentDataPath );
        
        this.back_stage.SetActive(false);
        PlayerPrefs.SetInt("LIFE", 5);
        PlayerPrefs.Save();
        root = uIDocument.rootVisualElement;
        this.root = this.uIDocument.rootVisualElement;
        
        //Label comment = this.root.Q<Label>("comment");
        //comment.text = "「Esc」で自殺できるよ(^o^)";
        
        

        this.button = this.root.Query<Button>();
        this.button.clickable.clicked += () => {
            Destroy(gameObject);
            this.back_stage.SetActive(true);
        };
        int i =0 ;
        root.Query<VisualElement>("level_wrapper").ForEach((VisualElement ele) => {
            this.level_wrapper_array.Add(ele);
            //string[] stage_array = System.IO.Directory.GetFiles(this.scene_path+"/"+ this.level_array[i] ,"*.unity",System.IO.SearchOption.AllDirectories);
            //string[] stage_array = UnityEditor.EditorBuildSettings.scenes;
            //Debug.Log(stage_array[0]);
            //foreach(var stage in SceneManager.GetActiveScene()){
            for(int j = 0; j < SceneManager.sceneCountInBuildSettings; j++){
                //stageのファイル構造の最後のファイル名をstage_nameに代入
                var stage =  SceneUtility.GetScenePathByBuildIndex(j);
                if (stage.Split('/','\\')[stage.Split('/','\\').Length-2] != this.level_path_array[i]){
                    continue;
                }
                string stage_name =stage.Split('/','\\','.')[stage.Split('/','\\','.').Length-2];
                Debug.Log(stage_name);
                Button button = new Button();
                button.name = this.level_array[i]+"_button";
                button.text = stage_name;
                button.clickable.clicked += () => {
                    Debug.Log("Button clicked");
                    PlayerPrefs.SetInt("LIFE", 5);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(stage_name);
                };
                ele.Add(button);
            }
            i++;
        });
    }

}
