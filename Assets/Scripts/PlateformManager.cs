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
	private readonly List<PlateformScript> currentObjects = new List<PlateformScript> ();
    private float width = 0;
    #endregion

    #region Scrolling Background Fields
    private readonly List<GameObject> backgroundList = new List<GameObject>();
    [SerializeField]
    private GameObject backgroundPrefab;
    private float backgroundSizeY;
    #endregion

    private readonly List<PairObject> wallList = new List<PairObject>();
    [SerializeField]
    private GameObject wallPrefab;
    private Vector2 wallSize;

    private Camera mainCamera;

    private float leftSide;
    private float rightSide;

    void Awake ()
    {
        mainCamera = Camera.main;

        backgroundSizeY = backgroundPrefab.GetComponent<Renderer>().bounds.size.y;
        wallSize = wallPrefab.GetComponent<Renderer>().bounds.size;

        float wallsWidth = wallSize.x * 2;

        for (int i = 0; i < plateformPrefabs.Length; ++i)
        {
            if (plateformPrefabs[i].Width + wallsWidth > width + wallsWidth)
                width = plateformPrefabs[i].Width + wallsWidth;
        }

        fixedX = startPoint.transform.position.x;

        leftSide = fixedX - width / 2;
        rightSide = fixedX + width / 2;

        float a = mainCamera.ViewportToWorldPoint(new Vector3(0.0F, 0.0F, -mainCamera.transform.position.z)).x;
        float b = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 0.0F, -mainCamera.transform.position.z)).x;
        float x1 = b - a;

        mainCamera.orthographicSize = mainCamera.orthographicSize * (width / x1);
    }

    void Start ()
	{
        CreateObstacle(0);

        while (!IsScreenFilled())
            CreateObstacle();

        while (!IsBackgroundFilled())
            CreateBackgroud();

        while (!IsWallsFilled())
            CreateWalls();
    }
	
	void Update ()
	{
        if (!IsScreenFilled())
            CreateObstacle();
        if (!IsBackgroundFilled())
            CreateBackgroud();
        if (!IsWallsFilled())
            CreateWalls();
        RemoveFirstPlateform();
	    RemoveFirstBackground();
        RemoveFirstPairWall();

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

    void CreateWalls()
    {
        Vector3 position = wallList.Count == 0 ? Vector3.zero : wallList[wallList.Count - 1].first.transform.position;
        position.x = fixedX;
        if (wallList.Count > 0)
            position.y -= wallSize.y;
        GameObject left = Instantiate(wallPrefab);
        GameObject right = Instantiate(wallPrefab);
        Vector3 posLeft = position;
        Vector3 posRight = position;
        posLeft.x = leftSide + wallSize.x / 2;
        posRight.x = rightSide - wallSize.x / 2;
        left.transform.position = posLeft;
        right.transform.position = posRight;

        wallList.Add(new PairObject(left, right));
    }

    private void CreateObstacle (int index = -1)
	{
        if (index < 0)
		    index = Random.Range (0, plateformPrefabs.Length);
        Vector3 position = new Vector3();
        position = currentObjects.Count == 0 ?
            startPoint.transform.position : currentObjects[currentObjects.Count - 1].GetBottomPoint();
        position.x = fixedX;
        position.y -= plateformPrefabs[index].Top;

        PlateformScript plateform = Instantiate(plateformPrefabs[index], position, plateformPrefabs[index].transform.rotation);
        currentObjects.Add(plateform);

        if (Random.Range(0, 1) == 0)
            plateform.transform.eulerAngles = new Vector3(0, 180);
	}

    public void RemoveFirstBackground()
    {
        if (backgroundList.Count > 0)
        {
            if (IsBackgroundGone(backgroundList[0]))
            {
                Destroy(backgroundList[0]);
                backgroundList.RemoveAt(0);
            }
        }
    }

    public void RemoveFirstPairWall()
    {
        if (wallList.Count > 0)
        {
            if (IsWallsGone(wallList[0]))
            {
                Destroy(wallList[0].first);
                Destroy(wallList[0].second);
                wallList.RemoveAt(0);
            }
        }
    }

    public void RemoveFirstPlateform()
    {
        if (currentObjects.Count > 0)
        {
            if (IsGone(currentObjects[0]))
            {
                Destroy(currentObjects[0]);
                currentObjects.RemoveAt(0);
            }
        }
    }

    private bool IsGone(PlateformScript plateform)
    {
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 1.0F, -mainCamera.transform.position.z));
        return screenTop.y < plateform.GetBottomPoint().y;
    }

    private bool IsBackgroundGone(GameObject background)
    {
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 1.0F, -mainCamera.transform.position.z));
        return screenTop.y < background.transform.position.y  - backgroundSizeY / 2;
    }

    private bool IsWallsGone(PairObject pairWall)
    {
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 1.0F, -mainCamera.transform.position.z));
        return screenTop.y < pairWall.first.transform.position.y - wallSize.y / 2;
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

    private bool IsWallsFilled()
    {
        if (wallList.Count == 0)
            return false;
        Vector3 screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 0.0F, -mainCamera.transform.position.z));
        return wallList[wallList.Count - 1].first.transform.position.y - (wallSize.y / 2) < screenBottom.y;
    }

    class PairObject
    {
        public GameObject first;
        public GameObject second;

        public PairObject(GameObject first, GameObject second)
        {
            this.first = first;
            this.second = second;
        }

    }
}