using TavernPuzzle.Scripts;
using UnityEngine;

public class MainMenuExitParams
{
    public SceneEnterParams TargetSceneEnterParams { get; }

    public MainMenuExitParams(SceneEnterParams targetSceneEnterParams)
    {
        TargetSceneEnterParams = targetSceneEnterParams;
    }
}
