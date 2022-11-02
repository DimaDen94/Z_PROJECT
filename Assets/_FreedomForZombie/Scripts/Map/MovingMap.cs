using UnityEngine;
public class MovingMap : MonoBehaviour
{
    [SerializeField] private int _mapNumber;

    private float _spriteWidth;
    private Vector2 _pixelWidth;
    void Awake()
    {
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        _pixelWidth = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0));
    }

    public float GetMaxDelta(float moveX, int lastPageConut)
    {
        if (_mapNumber == 0 && moveX > 0)
        {
            if (transform.position.x + moveX >= _spriteWidth / 2 - _pixelWidth.x)
                return 0;
        }
        else if (_mapNumber == lastPageConut && moveX < 0)
        {
            if (transform.position.x + moveX <= -(_spriteWidth / 2 - _pixelWidth.x))
                return -(_spriteWidth / 2 - _pixelWidth.x) - transform.position.x;
        }
        return moveX;
    }

    public void MoveToStartPosition()
    {
        transform.position = new Vector3((_spriteWidth / 2 - _pixelWidth.x) + (_spriteWidth * _mapNumber), transform.position.y, transform.position.z);
    }

    public void Move(float moveX)
    {
        transform.position = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z);
    }
}