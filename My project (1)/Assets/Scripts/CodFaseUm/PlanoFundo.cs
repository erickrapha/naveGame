using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoFundo : MonoBehaviour
{
    public Renderer renderer;
    public float velocity;
    
    private Material material;
    private Vector2 offsetMaterial;
    
    void Start()
    {
        this.renderer = this.renderer.material;
        this.offsetMaterial = this.material.GetTextureOffset("_MainTex");
    }
    void Update()
    {
        this.offsetMaterial.y -= this.velocity * Time.deltaTime;
        this.material.SetTextureOffset("_MainTex", this.offsetMaterial);
    }
}
