using UnityEngine;

public class BuildingCollection : MonoBehaviour
{
    private static BuildingCollection _current;

    [SerializeField] BuildingPool[] BuildingPools = null;

    private void Awake()
    {
        _current = this;
    }

    public static Building GetBuilding(float x)
    {
        Building building = _current.BuildingPools.GetRandom().GetItem();
        building.transform.position = new Vector3(x, 0);

        return building;
    }
}