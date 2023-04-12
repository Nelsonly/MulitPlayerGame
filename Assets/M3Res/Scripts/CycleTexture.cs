using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class CycleTexture : MonoBehaviour
{
    public Texture[] textures;
    public float speed = 0.1f;

    public int textureIndex;

    MaterialPropertyBlock mpb;
    // Update is called once per frame

    float lastTime;
    void Update()
    {
        if (speed < 0)
            speed = 0;

        if (speed > 0 && textures != null && textures.Length > 0) {

            if (Time.time - lastTime >= speed) {
                lastTime = Time.time;
                if (textureIndex >= textures.Length)
                    textureIndex = 0;

                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null) {
                    if (mpb == null)
                        mpb = new MaterialPropertyBlock();

                    if (textures[textureIndex] != null) {
                        renderer.GetPropertyBlock(mpb, 0);
                        mpb.SetTexture("_MainTex", textures[textureIndex]);
                        renderer.SetPropertyBlock(mpb, 0);
                    }

                    textureIndex++;
                }
            }
        }
    }
}
