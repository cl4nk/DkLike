using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformScript : MonoBehaviour {

    [SerializeField]
    private float top;
    public float Top
    {
        get { return top; }
    }

    [SerializeField]
    private float bottom;
    public float Bottom
    {
        get { return bottom; }
    }

    [SerializeField]
    private float gizmosSphereRadius = 0.2f;

    [SerializeField]
    private float width = 15.0f;
    public float Width
    {
        get { return width; }
    }

    public Vector3 GetBottomPoint()
    {
        Vector3 result = transform.position;
        result.y -= bottom;
        return result;
    }

    public Vector3 GetTopPoint()
    {
        Vector3 result = transform.position;
        result.y += top;
        return result;
    }


    private void OnDrawGizmos()
    {
        float x1 = transform.position.x - (width / 2);
        float x2 = transform.position.x + (width / 2);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(x1, transform.position.y + top, 0), new Vector3(x2, transform.position.y + top, 0));
        Gizmos.DrawSphere(GetTopPoint(), gizmosSphereRadius);
        Gizmos.DrawLine(new Vector3(x1, transform.position.y - bottom, 0), new Vector3(x2, transform.position.y - bottom, 0));
        Gizmos.DrawSphere(GetBottomPoint(), gizmosSphereRadius);

        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        Gizmos.DrawSphere(transform.position, gizmosSphereRadius / 2);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color (1.0f, 0.0f, 0.0f, 0.5f);
        Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + (top - bottom) / 2, 0), new Vector3(width, top + bottom, 1));
    }
}
