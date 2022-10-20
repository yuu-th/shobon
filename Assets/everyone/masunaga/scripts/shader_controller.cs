using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class shader_controller : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    [HideInInspector] public bool mazai3 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(mazai3 == true)
        {
            shader_on();
        }
        else if(mazai3 == false)
        {
            shader_off();
        }
    }

    void OnDestroy()
    {
        //　作成したボリュームの削除
        RuntimeUtilities.DestroyVolume(postProcessVolume, true, true);
    }

    void shader_on()
    {
        ChromaticAberration chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.enabled.Override(true);
        chromatic.intensity.Override(3f);
        //　ポストプロセスボリュームに反映
        postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, chromatic);
    }

    void shader_off()
    {
        ChromaticAberration chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.enabled.Override(false);
        chromatic.intensity.Override(0f);
        postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, chromatic);
    }
}
