using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;
    [SerializeField] private MeshRenderer _renderer;

    public bool HasTower { get; private set; } = false;

    public void Select() => _renderer.material.color = Color.magenta;

    public void Deselect() => _renderer.material.color = Color.white;

    internal void PlaceTower(GameObject tower)
    {
        HasTower = true;
        Instantiate(tower, _placePoint.position, Quaternion.identity, _placePoint);
    }
}

