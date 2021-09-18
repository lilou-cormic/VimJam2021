using UnityEngine;

public class BuildingCollection : MonoBehaviour
{
    private static BuildingCollection _current;

    [SerializeField] BuildingPool[] BuildingPools = null;

    private void Awake()
    {
        _current = this;
    }

    public static Building GetBuilding(float prevHeight, float x)
    {
        Building building;

        do
        {
            building = _current.BuildingPools.GetRandom().GetItem();
            building.gameObject.SetActive(false);
        } while (Mathf.Abs(building.Height - prevHeight) > 2);

        building.transform.position = new Vector3(x, 0);
        building.gameObject.SetActive(true);

        return building;
    }
}