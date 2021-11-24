using UnityEngine;

public class InputAWSD : MonoBehaviour
{
    private PlayerController _player;
    private void Start()
    {
        _player = GetComponentInChildren<PlayerController>(); 
    }

    
    private void Update()
    {
        //В зависимости от нажатой клавиши, в игрока запускается свой метод направления движения.
        if (Input.GetKey(KeyCode.W)) 
        {
            _player.MoveUp();
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            _player.MoveDown();
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            _player.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            _player.MoveRight();
        }
    }
}
