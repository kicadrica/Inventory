using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<int> OnKeyChange;
    public InventorySO PlayerInventory;
    public bool HasKeys => _keys > 0;
    
    private int _keys = 0;
    private int Keys {
        get => _keys;
        set {
            _keys = value;
            OnKeyChange?.Invoke(_keys);
        } 
    }
    
    [SerializeField] private Sprite SpriteFront; 
    [SerializeField] private Sprite SpriteBack; 
    [SerializeField] private Sprite AttackUp; 
    [SerializeField] private Sprite AttackDown; 
    [SerializeField] private Sprite AttackFront;
    
    private SpriteRenderer _sr; 
    private float _moveDelay = 0.3f;
    private float _currentDelay = 0;
    private Vector2 _cachedDir;
    
    private void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        Keys = 0;
    }

    public void MoveUp() //Метод направления движения игрока.
    {
        _sr.sprite = SpriteBack; //В переменную содержащую SpriteRenderer обращается к спрайту и записываем изображение.
        MoveToDirection(Vector3.up); //В метод отвечающий за движение передается аргумент с направлением. 
    }
    public void MoveDown()
    {
        _sr.sprite = SpriteFront;
        MoveToDirection(Vector3.down);
    }
    public void MoveLeft()
    {
        _sr.sprite = SpriteFront;
        _sr.flipX = true; 
        MoveToDirection(Vector3.left);
    }
    public void MoveRight()
    {
        _sr.flipX = false;
        _sr.sprite = SpriteFront;
        MoveToDirection(Vector3.right);
    }

    private void Update()
    {
        if (_cachedDir != Vector2.zero) {
            Vector3 dir = _cachedDir;
            _cachedDir = Vector2.zero;
            MoveToDirection(dir);
        }
    }

    private void MoveToDirection(Vector3 direction) //Метод отвечающий за движение.
    {
        if (_currentDelay < _moveDelay) {
            _currentDelay += Time.deltaTime;
            _cachedDir = direction;
            return;
        }
        _cachedDir = Vector2.zero;
        _currentDelay = 0;
        Vector3 destination = transform.position + direction; 

        Collider2D col = Physics2D.OverlapPoint(destination); //Проверяет наличие коллайдера в точке, в которую игрок намеревается пойти. При обнаружении записывает его в переменную.
        
        if (col)
        {
            var attackableItem = col.GetComponentInParent<IAttackable>(); 
            if (attackableItem != null) 
            {
                attackableItem.AttackBy(this.gameObject); //В качестве аргумента передается атакуемый объект.
                StartCoroutine(AnimateAttack(direction)); //Запускается коротина анимации атаки. В метод передается аргумент с направлением.
                return; 
            }

            var collectItem = col.GetComponentInParent<ICollectable>(); 
            if (collectItem != null) 
            {
                transform.position = destination; //Текущая позиция игрока меняется на новую.
                collectItem.CollectBy(this.gameObject); //В качестве аргумента передается объект, который собрал предмет.
                return; 
            }

            var pushItem = col.GetComponentInParent<IPushable>(); 
            if (pushItem != null) 
            {
                pushItem.PushBy(this.gameObject); //В качестве аргумента передается объект, который толкает предмет.
            }
            
            col = Physics2D.OverlapPoint(destination); // Еще раз проверяет наличие колайдера в точке. 
            if (col) return;
        }

        transform.position = destination; //Текущей позиции игрока присваивается новая позиция.
        
    }
    private IEnumerator AnimateAttack(Vector3 direction) //Создание коротины анимации атаки игрока с входным параметром отвечающим за направление.
    {
        var prevSprite = _sr.sprite; //Запись текущего спрайта в переменную.
        if (direction == Vector3.up) //Если направление вверх...
        {
            _sr.sprite = AttackUp; //... текущему спрайту присваивается спрайт атаки вверх.
        }
        else if (direction == Vector3.down) // Иначе если направление вниз...
        {
            _sr.sprite = AttackDown; //... текущему спрайту присваивается спрайт атаки вниз.
        }
        else //Иначе текущему спрайту присваивается спрайт атаки в сторону.
        {
            _sr.sprite = AttackFront;
        }
        
        yield return new WaitForSeconds(0.15f); //После удара отсчитывается время.
        _sr.sprite = prevSprite; //Текущему спрайту атаки присваивается первоначальный спрайт.
    }
    
    public void CollectKey() 
    {
        Keys++;
    }
    
    public void RemoveKey() 
    {
        Keys--;
    }
}
