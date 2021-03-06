using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRadioWaves : MonoBehaviour
{
	protected Transform m_Transform;

	[SerializeField]
	protected LineRenderer m_LineRenderer;
	[SerializeField]
	protected EdgeCollider2D m_EdgeCollider2D;
	[SerializeField]
	protected Camera m_Camera;

    public float m_Intensity = 300f;

    public float spread = 30f;  //use ##f to define the spread of the radio waves
    public float speed = 300f;

    Vector2 m_Center;

    float m_StartIntensity;
	int m_StartDegree;
	int m_EndDegree;
    float m_Distance;

    float speedModifier = 200f;
    float intensityModifier = 75f;

    void Start () {
		m_Transform = GetComponent<Transform>();
        m_Distance = 0;
        drawRadioWave (m_Transform.position, (int)((m_Transform.rotation.eulerAngles.z)-(spread/2)), (int)((m_Transform.rotation.eulerAngles.z)+(spread/2)));
	}


	public virtual LineRenderer lineRenderer
	{
		get
		{
			return m_LineRenderer;
		}
	}

	public virtual EdgeCollider2D edgeCollider2D
	{
		get
		{
			return m_EdgeCollider2D;
		}
	}

	protected virtual void Awake ()
	{
		if ( m_LineRenderer == null )
		{
			//Debug.LogWarning ( "DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer." );
			CreateDefaultLineRenderer ();
		}
		if ( m_EdgeCollider2D == null )
		{
			//Debug.LogWarning ( "DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D." );
			CreateDefaultEdgeCollider2D ();
		}
		if ( m_Camera == null ) {
			m_Camera = Camera.main;
		}
	}

	protected virtual void Update()
    {
        if (m_Intensity > 0)
        {
            m_Intensity -= (Time.deltaTime * intensityModifier);
            m_Distance += (Time.deltaTime * speed / speedModifier);
            drawArc (m_Center, m_Distance, m_StartDegree, m_EndDegree, m_Intensity);
		} else {
			Destroy (gameObject);
		}
	}

	public void drawRadioWave(Vector2 center, int startDegree, int endDegree) {
        m_Center = center;
        m_StartIntensity = m_Intensity;
		m_StartDegree = startDegree;
		m_EndDegree = endDegree;
        drawArc (m_Center, m_Distance, m_StartDegree, m_EndDegree, m_Intensity);
	}
			

	public virtual void drawArc (Vector2 center, float radius, int startDegree, int endDegree, float intensity) {
		
		Reset ();

		List<Vector2> points = new List<Vector2>();

		int lStartDegree = startDegree % 360;
		int lEndDegree = endDegree % 360;

		if (lEndDegree < lStartDegree) {
			lEndDegree += 360;
		}
		for (int i = lStartDegree; i <= lEndDegree; i+=10) {
			Vector2 arcPoint = new Vector2 ();
			arcPoint.y = radius * Mathf.Sin(((float)i%360f)/360f*2f*Mathf.PI) + center.y;
			arcPoint.x = radius * Mathf.Cos(((float)i%360f)/360f*2f*Mathf.PI) + center.x;
			if (!points.Contains (arcPoint)) {
				points.Add (arcPoint);
				m_LineRenderer.startColor = new Color (1, 1, 1, intensity/m_StartIntensity);
				m_LineRenderer.endColor = new Color (1, 1, 1, intensity/m_StartIntensity);
				m_LineRenderer.positionCount = points.Count;
				m_LineRenderer.SetPosition (m_LineRenderer.positionCount - 1, arcPoint);
			}
		}

		if (points.Count > 1) {
			if (m_EdgeCollider2D != null) {
				m_EdgeCollider2D.points = points.ToArray ();
				m_EdgeCollider2D.isTrigger = true;
				m_EdgeCollider2D.tag = "Radio Wave";
			}
		}
	}

	protected virtual void Reset ()
	{
		if ( m_LineRenderer != null )
		{
			m_LineRenderer.positionCount = 0;
		}
		if ( m_EdgeCollider2D != null )
		{
			m_EdgeCollider2D.Reset ();
			m_EdgeCollider2D.transform.SetPositionAndRotation(new Vector3(0,0), new Quaternion(0,0,0,0));
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