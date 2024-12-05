using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private GameObject _towerTemplate;
    private Dot _selected;

    private void Update()
    {
        ReadInput();

        //Hack: Temp Solution
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaceTower(_towerTemplate);
        }
    }

    private void ReadInput()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if (TryGetSelectableUnderPointer(out Dot dot))
            {
                _selected?.Deselect();
                _selected = dot;
                _selected.Select();
               
            }
        }
    
    }

    private bool TryGetSelectableUnderPointer(out Dot dot)
    {
        dot = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out Dot hitted))
            {
                dot = hitted;
                return true;
            }
        }

        return false;
    }

    public void PlaceTower(GameObject tower)
    {
        if (CanPlace() == false)
        {
            return;
        }


        if (_selected != null)
        {
            _selected.PlaceTower(tower);
        }
    }

    private bool CanPlace() => _selected.HasTower == false;
}

