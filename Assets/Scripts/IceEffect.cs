using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEffect : MonoBehaviour
{
    private SpriteRenderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        Color color = m_Renderer.color;
        if (color.a > 0.0001f)
        {
            color.a -= 0.001f;
            if (color.a < 0.0f) color.a = 0.0f;
            m_Renderer.color = color;
        }
    }
}
