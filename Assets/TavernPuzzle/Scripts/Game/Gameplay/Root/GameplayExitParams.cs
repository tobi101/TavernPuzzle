using UnityEngine;

public class GameplayExitParams
{
    public MainMenuEnterParams MainMenuEnterParams { get; }

    public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams) 
    {
        MainMenuEnterParams = mainMenuEnterParams;
    }
}
