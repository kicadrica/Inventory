using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InventorySO PlayerInventory;
    public int Keys = 0; //Переменная содержит количество ключей.
    public Sprite SpriteFront; //Переменная для изображения передней части игрока. Спрайт назначается в инспекторе.
    public Sprite SpriteBack; //Переменная для изображения задней части игрока. Спрайт назначается в инспекторе.
    public Sprite AttackUp; //Переменная для изображения атаки игроком сверху. Спрайт назначается в инспекторе.
    public Sprite AttackDown; //Переменная для изображения атаки игроком снизу. Спрайт назначается в инспекторе.
    public Sprite AttackFront; //Переменная для изображения атаки игроком сбоку. Спрайт назначается в инспекторе.
    
    private SpriteRenderer sr; 
    private float _moveDelay = 0.3f;
    private float _currentDelay = 0;
    private Vector2 _cachedDir;
    
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>(); //Получения компонента SpriteRenderer.
    }

    public void MoveUp() //Метод направления движения игрока.
    {
        sr.sprite = SpriteBack; //В переменную содержащую SpriteRenderer обращается к спрайту и записываем изображение.
        MoveToDirection(Vector3.up); //В метод отвечающий за движение передается аргумент с направлением. 
    }
    public void MoveDown()
    {
        sr.sprite = SpriteFront;
        MoveToDirection(Vector3.down);
    }
    public void MoveLeft()
    {
        sr.sprite = SpriteFront;
        sr.flipX = true; 
        MoveToDirection(Vector3.left);
    }
    public void MoveRight()
    {
        sr.flipX = false;
        sr.sprite = SpriteFront;
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
        Vector3 destination = transform.position + direction; //До текущей позиции добавляется входящий параметр направления и записывается в переменную.

        Collider2D col = Physics2D.OverlapPoint(destination); //Проверяет наличие коллайдера в точке, в которую игрок намеревается пойти. При обнаружении записывает его в переменную.
        
        if (col) //Проверка на обнаружение колайдера.
        {
            IAttackable attackableItem = col.GetComponentInParent<IAttackable>(); //Поиск у колайдера компонента IAttackable.
            if (attackableItem != null) //Если у колайдера обнаружен компонент IAttackable...
            {
                attackableItem.AttackBy(this.gameObject); //...у объекта с компонентом IAttackable срабатывает метод атаки. В качестве аргумента передается атакуемый объект.
                StartCoroutine(AnimateAttack(direction)); //Запускается коротина анимации атаки. В метод передается аргумент с направлением.
                return; // Прерывает метод движения.
            }

            ICollectable collectItem = col.GetComponentInParent<ICollectable>(); //Поиск у колайдера компонента ICollectable;
            if (collectItem != null) //Если у колайдера обнаружен компонент ICollectable...
            {
                transform.position = destination; //Текущая позиция игрока меняется на новую.
                collectItem.CollectBy(this.gameObject); //Вызывается метод сбора. В качестве аргумента передается объект, который собрал предмет.
                return; // Прерывает метод движения.
            }

            IPushable pushItem = col.GetComponentInParent<IPushable>(); //Поиск у колайдера компонента IPushable.
            if (pushItem != null) //Если у колайдера обнаружен компонент IPushable.
            {
                pushItem.PushBy(this.gameObject); //У компонента IPushable срабатывает метод PushBy. В качестве аргумента передается объект, который толкает предмет.
            }
            col = Physics2D.OverlapPoint(destination); // Еще раз проверяет наличие колайдера в точке. 
            if (col)
            {
                return; //Прерывает метод движения.
            }


        }

        transform.position = destination; //Текущей позиции игрока присваивается новая позиция.
      
    }
    private IEnumerator AnimateAttack(Vector3 direction) //Создание коротины анимации атаки игрока с входным параметром отвечающим за направление.
    {
        var prevSprite = sr.sprite; //Запись текущего спрайта в переменную.
        if (direction == Vector3.up) //Если направление вверх...
        {
            sr.sprite = AttackUp; //... текущему спрайту присваивается спрайт атаки вверх.
        }
        else if (direction == Vector3.down) // Иначе если направление вниз...
        {
            sr.sprite = AttackDown; //... текущему спрайту присваивается спрайт атаки вниз.
        }
        else //Иначе текущему спрайту присваивается спрайт атаки в сторону.
        {
            sr.sprite = AttackFront;
        }
        yield return new WaitForSeconds(0.15f); //После удара отсчитывается время.
        sr.sprite = prevSprite; //Текущему спрайту атаки присваивается первоначальный спрайт.
    }
    
    public void CollectKey() //Метод увеличивающий количество ключей на 1.
    {
        Keys++;
    }
}
