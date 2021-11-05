using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private MeshRenderer mainMesh;
    [SerializeField] private MeshRenderer eyeBrow_01;
    [SerializeField] private MeshRenderer eyeBrow_02;
    [SerializeField] private float fadeInDelay = 17;
    [SerializeField] private float fadeInDuration = 0.5f;

    private static string alpha = "_Alpha";
    private static string outlineColor = "_OutlineColorVertex";

    private Material mainMat;
    private Material eyeBrowMat_01;
    private Material eyeBrowMat_02;

    private void Awake()
    {
        if (mainMesh == null)
            return;

        mainMat = mainMesh.material;
        eyeBrowMat_01 = eyeBrow_01.material;
        eyeBrowMat_02 = eyeBrow_02.material;

        var transpColor = new Color(0,0,0,0);

        mainMat.SetFloat(alpha, 0);
        mainMat.SetColor(outlineColor, transpColor);
        eyeBrowMat_01.SetFloat(alpha, 0);
        eyeBrowMat_02.SetFloat(alpha, 0);

        LeanTween.delayedCall(gameObject, fadeInDelay, () => {
            LeanTween.value(gameObject, 0, 1, fadeInDuration).setOnUpdate((float val) => {
                mainMat.SetFloat(alpha, val);
                mainMat.SetColor(outlineColor, new Color(0,0,0,val));
                eyeBrowMat_01.SetFloat(alpha, val);
                eyeBrowMat_02.SetFloat(alpha, val);
            });
        });
    }

}
