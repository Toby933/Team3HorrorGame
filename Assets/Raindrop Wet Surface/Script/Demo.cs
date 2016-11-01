using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
	public Material m_RaindropMat;
	public Texture2D m_RaindropMap;
	public GameObject m_Light;
	public GameObject[] m_RaindropObjects;
	[Range(0.1f, 3f)] public float m_TimeMultiply = 1.5f;
	[Range(0f, 1f)] public float m_Wetness = 0.5f;
	[Range(0f, 1f)] public float m_Rain = 1f;
	private RenderTexture m_RaindropGenerated;
	
    void Start ()
	{
		m_RaindropGenerated = new RenderTexture (256, 256, 24);
		m_RaindropGenerated.name = "Raindrop";
		m_RaindropGenerated.wrapMode = TextureWrapMode.Repeat;
	}
	Vector4 Frac (Vector4 v)
	{
		return new Vector4 (
			(float)(v.x - (int)v.x),
			(float)(v.y - (int)v.y),
			(float)(v.z - (int)v.z),
			(float)(v.w - (int)v.w));
	}
	void Update ()
    {
		Vector4 tMul = new Vector4 (1.0f, 0.85f, 0.93f, 1.13f);
		Vector4 tAdd = new Vector4 (0.0f, 0.2f, 0.45f, 0.7f);
		Vector4 t = (Time.time * tMul + tAdd) * m_TimeMultiply;
		t = Frac (t);
		m_RaindropMat.SetVector ("_RainTime", t);
		m_RaindropMat.SetFloat ("_RainIntensity", m_Rain);
		Graphics.Blit (m_RaindropMap, m_RaindropGenerated, m_RaindropMat);
		for (int i = 0; i < m_RaindropObjects.Length; i++)
		{
			Renderer rd = m_RaindropObjects[i].GetComponent<Renderer>();
			rd.material.SetTexture ("_RippleTex", m_RaindropGenerated);
			rd.material.SetVector ("_LightPosition", m_Light.transform.position);
			rd.material.SetFloat ("_WetLevel", m_Wetness * 0.7f);
			rd.material.SetFloat ("_FloodLevel2", m_Wetness * 2f);
			rd.material.SetFloat ("_FloodLevel1", Mathf.Min(m_Wetness * 2f, 1f));
		}
    }
	void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, 240, 25), "Raindrop Wet Surface Demo");
	}
}
