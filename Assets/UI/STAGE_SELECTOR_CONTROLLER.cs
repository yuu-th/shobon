using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class STAGE_SELECTOR_CONTROLLER : MonoBehaviour
{
    public UIDocument uIDocument = null;
    private VisualElement body;
    private Button button;

    private VisualElement[] level_wrapper_array = new VisualElement[5];
    // Start is called before the first frame update
    void Start()
    {
        this.body = this.uIDocument.rootVisualElement;
        this.button = this.body.Query<Button>();
        this.button.clickable.clicked += () => {
            Debug.Log("Button clicked");
        };
        
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
