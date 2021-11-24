using UnityEngine;

public class InputArrows : MonoBehaviour
{
    private PlayerController _player; 
    private void Start()
    {
        _player = GetComponentInChildren<PlayerController>(); 
    }

   
    private void Update()
    {
        //В зависимости от нажатой стрелки, в игрока запускается свой метод направления движения.
        if (Input.GetKey(KeyCode.UpArrow)) 
        { 
            _player.MoveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            _player.MoveDown();
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            _player.MoveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            _player.MoveRight();
        }
    }
}
