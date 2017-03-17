using UnityEngine;
using System.Collections.Generic;

public class PlateformManager : MonoBehaviour
{
    [SerializeField]
    private float fixedX = 0;

	public PlateformScript[] plateformPrefabs;
	private List<PlateformScript> currentObjects = new List<PlateformScript> ();

	void Start ()
	{
        CreateObstacle(0);

        while (!IsScreenFilled())
            CreateObstacle();
    }
	
	void Update ()
	{
        if (!IsScreenFilled())
            CreateObstacle();
		if (currentObjects.Count > 0) {
            if (IsGone(currentObjects[0]))
            {
                Destroy(currentObjects[0]);
                currentObjects.RemoveAt(0);
            }
		}
	}

	private void CreateObstacle (int index = -1)
	{
        if (index < 0)
		    index = Random.Range (0, plateformPrefabs.Length);
        Vector3 position = new Vector3();
        position = currentObjects.Count == 0 ? 
            GameManager.Instance.playerPrefab.transform.position : currentObjects[currentObjects.Count - 1].GetBottomPoint();
        position.x = fixedX;
        position.y -= plateformPrefabs[index].Bottom;

        PlateformScript plateform = Instantiate(plateformPrefabs[index], position, plateformPrefabs[index].transform.rotation);
        currentObjects.Add(plateform);
	}

    private bool IsGone(PlateformScript plateform)
    {
        Vector3 screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0.5F, 1.0F, 0));
        return screenTop.y < plateform.GetBottomPoint().y;
    }

    private bool IsScreenFilled ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.0F, 0));

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            return true;
        }
        return false;
    }

}