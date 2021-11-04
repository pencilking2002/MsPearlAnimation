using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
[TrackBindingType(typeof(PuppetFace.LipSync))]
[TrackClipType(typeof(LipSyncClip))]

public class LipSyncTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<LipSyncBehaviour>.Create(graph, inputCount);
    }
}
