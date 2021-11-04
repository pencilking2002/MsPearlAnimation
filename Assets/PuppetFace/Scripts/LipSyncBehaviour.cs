using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LipSyncBehaviour : PlayableBehaviour
{
    public int LipSyncIndex;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        PuppetFace.LipSync lipSync = playerData as PuppetFace.LipSync;

        if (!lipSync)
            return;

        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LipSyncBehaviour> inputPlayable = (ScriptPlayable<LipSyncBehaviour>)playable.GetInput(i);
            LipSyncBehaviour input = inputPlayable.GetBehaviour();
            
            if (inputWeight > 0)
            {
                float timeVal = (float)inputPlayable.GetTime();

                #if UNITY_EDITOR
                if (!lipSync.Initialized)
                    lipSync.InitializeFromFile();
                #endif
                if (input.LipSyncIndex < lipSync.LipSyncFiles.Length)
                    lipSync.SetPhoneme(input.LipSyncIndex, timeVal);

            }

        }

       



        

    }
}
