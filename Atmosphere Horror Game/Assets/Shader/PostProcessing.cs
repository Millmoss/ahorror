using UnityEngine;

[ExecuteInEditMode]
public class PostProcessing : MonoBehaviour
{

    public Material material;
    private float memes = 0.0000000001f;
    private float max_size = 0.4f;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

    private void Update()
    {
        if(memes < max_size)
            memes += Time.deltaTime / 10000;
        //material.SetFloat("_Size", memes);
    }
}