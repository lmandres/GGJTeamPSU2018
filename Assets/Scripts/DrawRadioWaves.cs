using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRadioWaves : MonoBehaviour
{

	[SerializeField]
	protected LineRenderer m_LineRenderer;
	[SerializeField]
	protected bool m_AddCollider = false;
	[SerializeField]
	protected EdgeCollider2D m_EdgeCollider2D;
	[SerializeField]
	protected Camera m_Camera;
	protected List<Vector2> m_Points;

	int m_Intensity;
	int m_StartIntensity;
	Vector2 m_Center;
	int m_StartDegree;
	int m_EndDegree;


	public virtual LineRenderer lineRenderer
	{
		get
		{
			return m_LineRenderer;
		}
	}

	public virtual bool addCollider
	{
		get
		{
			return m_AddCollider;
		}
	}

	public virtual EdgeCollider2D edgeCollider2D
	{
		get
		{
			return m_EdgeCollider2D;
		}
	}

	public virtual List<Vector2> points
	{
		get
		{
			return m_Points;
		}
	}

	protected virtual void Awake ()
	{
		if ( m_LineRenderer == null )
		{
			Debug.LogWarning ( "DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer." );
			CreateDefaultLineRenderer ();
		}
		if ( m_EdgeCollider2D == null && m_AddCollider )
		{
			Debug.LogWarning ( "DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D." );
			CreateDefaultEdgeCollider2D ();
		}
		if ( m_Camera == null ) {
			m_Camera = Camera.main;
		}
		m_Points = new List<Vector2> ();
	}

	protected virtual void Update() {
		if (Input.GetMouseButtonDown (0)) {
			drawRadioWave (m_Camera.ScreenToWorldPoint (Input.mousePosition), 180, 360, 300);
		}
		if (m_Intensity < m_StartIntensity) {
			m_Intensity++;
			drawArc (m_Center, ((float)m_Intensity/(float)30) , m_StartDegree, m_EndDegree, m_Intensity);
		}
	}

	public virtual void drawRadioWave(Vector2 center, int startDegree, int endDegree, int startIntensity) {
		m_StartIntensity = startIntensity;
		m_Intensity = 0;
		m_Center = center;
		m_StartDegree = startDegree;
		m_EndDegree = endDegree;
		drawArc (m_Center, ((float)m_Intensity/(float)30) , m_StartDegree, m_EndDegree, m_Intensity);
	}
			

	public virtual void drawArc (Vector2 center, float radius, int startDegree, int endDegree, int intensity) {
		Reset ();
		for (int i = startDegree; i <= endDegree; i++) {
			Vector2 arcPoint = new Vector2 ();
			arcPoint.y = radius * Mathf.Sin((float)i/360f*2f*Mathf.PI) + center.y;
			arcPoint.x = radius * Mathf.Cos((float)i/360f*2f*Mathf.PI) + center.x;
			if (!m_Points.Contains (arcPoint)) {
				m_Points.Add (arcPoint);
				m_LineRenderer.startColor = new Color (1, 1, 1,( (float)m_StartIntensity - (float)intensity )/ (float)m_StartIntensity);
				m_LineRenderer.endColor = new Color (1, 1, 1,( (float)m_StartIntensity - (float)intensity) / (float)m_StartIntensity);
				m_LineRenderer.positionCount = m_Points.Count;
				m_LineRenderer.SetPosition (m_LineRenderer.positionCount - 1, arcPoint);
			}
		}

		if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1) {
			m_EdgeCollider2D.points = m_Points.ToArray ();
		}
	}

	protected virtual void Reset ()
	{
		if ( m_LineRenderer != null )
		{
			m_LineRenderer.positionCount = 0;
		}
		if ( m_Points != null )
		{
			m_Points.Clear ();
		}
		if ( m_EdgeCollider2D != null && m_AddCollider )
		{
			m_EdgeCollider2D.Reset ();
		}
	}

	protected virtual void CreateDefaultLineRenderer ()
	{
		m_LineRenderer = gameObject.AddComponent<LineRenderer> ();
		m_LineRenderer.positionCount = 0;
		m_LineRenderer.material = new Material ( Shader.Find ( "Particles/Additive" ) );
		m_LineRenderer.startColor = Color.white;
		m_LineRenderer.endColor = Color.white;
		m_LineRenderer.startWidth = 0.1f;
		m_LineRenderer.endWidth = 0.1f;
		m_LineRenderer.useWorldSpace = true;
		m_LineRenderer.sortingLayerName = "Transmissions";
	}

	protected virtual void CreateDefaultEdgeCollider2D ()
	{
		m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D> ();
	}

}