using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ShaderPropertyAnim : MonoBehaviour
{
    public float blur;

    public float brightness;


    SpriteRenderer spriteRenderer;



    float lastBlur, lastBrightness;

    void Start() {
        UpdateShaderProperties(true);
    }

    MaterialPropertyBlock propertyBlock;

    void UpdateShaderProperties(bool force) {
        if (force || blur != lastBlur || brightness != lastBrightness) {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
                return;

            lastBlur = blur;
            lastBrightness = brightness;
            if (propertyBlock == null)
                propertyBlock = new MaterialPropertyBlock();

            spriteRenderer.GetPropertyBlock(propertyBlock);

            propertyBlock.SetFloat("_BlurIntensity", blur);
            propertyBlock.SetFloat("_Brightness", brightness);

            spriteRenderer.SetPropertyBlock(propertyBlock, 0);
        }
    }

    void Update()
    {
        UpdateShaderProperties(false);
    }

}
