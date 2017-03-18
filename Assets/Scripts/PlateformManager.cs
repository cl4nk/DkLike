using UnityEngine;
using System.Collections.Generic;

public class PlateformManager : MonoBehaviour
{

    private static PlateformManager instance;
    public static PlateformManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlateformManager>();
            }
            return instance;
        }
    }

    #region Plateform Fields
    public float fixedX = 0;
    [SerializeField]
    private GameObject startPoint;
    [SerializeField]
    private PlateformScript[] plateformPrefabs;
	private List<PlateformScript> currentObjects = new List<PlateformScript> ();
    #endregion

    #region Scrolling Background Fields
    private List<GameObject> backgroundList = new List<GameObject>();
    [SerializeField]
    private GameObject backgroundPrefab;
    private float backgroundSizeY;
    #endregion

    private Camera mainCamera;

    void Start ()
	{
        mainCamera = Camera.main;

        CreateObstacle(0);

        while (!IsScreenFilled())
            CreateObstacle();

        backgroundSizeY = backgroundPrefab.GetComponent<Renderer>().bounds.size.y;

        while (!IsBackgroundFilled())
            CreateBackgroud();
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

    void CreateBackgroud ()
    {
        Vector3 position = backgroundList.Count == 0 ? Vector3.zero : backgroundList[backgroundList.Count - 1].transform.position;
        position.x = fixedX;
        if (backgroundList.Count > 0)
            position.y -= backgroundSizeY;
        GameObject obj = Instantiate(backgroundPrefab);
        obj.transform.position = position;

        backgroundList.Add(obj);
    }

	private void CreateObstacle (int index = -1)
	{
        if (index < 0)
		    index = Random.Range (0, plateformPrefabs.Length);
        Vector3 position = new Vector3();
        position = currentObjects.Count == 0 ?
            startPoint.transform.position : currentObjects[currentObjects.Count - 1].GetBottomPoint();
        position.x = fixedX;
        position.y -= plateformPrefabs[index].Bottom;

        PlateformScript plateform = Instantiate(plateformPrefabs[index], position, plateformPrefabs[index].transform.rotation);
        currentObjects.Add(plateform);

        if (Random.Range(0, 1) == 0)
            plateform.transform.eulerAngles = new Vector3(0, 180);
	}

    private bool IsGone(PlateformScript plateform)
    {
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 1.0F, -mainCamera.transform.position.z));
        return screenTop.y < plateform.GetBottomPoint().y;
    }

    private bool IsScreenFilled ()
    {
        if (currentObjects.Count == 0)
            return false;
        Vector3 screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 0.0F,- mainCamera.transform.position.z));
        return currentObjects[currentObjects.Count - 1].GetBottomPoint().y < screenBottom.y;
    }

    private bool IsBackgroundFilled()
    {
        if (backgroundList.Count == 0)
            return false;
        Vector3 screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 0.0F, -mainCamera.transform.position.z));
        return backgroundList[backgroundList.Count - 1].transform.position.y - (backgroundSizeY /2) < screenBottom.y;
    }


}