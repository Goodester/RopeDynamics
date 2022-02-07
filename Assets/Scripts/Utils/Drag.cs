using Unity.Mathematics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Utils
{
    public class Drag : MonoBehaviour
    {
        private GameObject _selectedObject;
        private Vector3 _offset;
        private Camera _mainCamera;
        private Vector3 _mousePosition;
        
        private void Start()
        {
            _mainCamera = Camera.main;
        }
    
        private void Update()
        {
            _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject();
            }
    
            if (_selectedObject)
            {
                MoveSelectedObject();
            }
            
            if (Input.GetMouseButtonUp(0) && _selectedObject)
            {
                DeSelectObject();
            }
        }
    
        private void SelectObject()
        {
            Collider2D selectedCollider = Physics2D.OverlapPoint(_mousePosition);
                
            if (selectedCollider && selectedCollider.transform.gameObject.CompareTag("Draggable"))
            {
                _selectedObject = selectedCollider.transform.gameObject;
                _offset = _selectedObject.transform.position - _mousePosition;
            }
        }
    
        private void MoveSelectedObject()
        {
            Vector3 dummyPos = _selectedObject.transform.position;
            dummyPos.y = math.max(
                math.min(_mousePosition.y + _offset.y, Globals.PipeWrenchMaxY), Globals.PipeWrenchMinY
                );
            Vector3 newPos = dummyPos;
    
            _selectedObject.transform.position = newPos;
        }
    
        private void DeSelectObject()
        {
            _selectedObject = null;
        }
    }
}
