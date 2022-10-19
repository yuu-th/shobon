using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class shader_controller : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDestroy()
    {
        //　作成したボリュームの削除
        RuntimeUtilities.DestroyVolume(postProcessVolume, true, true);
    }

    public void shader_on()
    {
        ChromaticAberration chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.enabled.Override(true);
        chromatic.intensity.Override(3f);
        //　ポストプロセスボリュームに反映
        postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, chromatic);
    }
}
