using System.Collections.Generic;
using UnityEngine;

public class TimerImageSpawner : MonoBehaviour
{
    [SerializeField] private Object _imagePrefab;
    [SerializeField] private Queue<Object> _imageQueue = new Queue<Object>();

    public int ImageCount => _imageQueue.Count;

    public void ToSpawn()
    {
        Object image = Instantiate(_imagePrefab, this.gameObject.transform);
        _imageQueue.Enqueue(image);
    }

    public void ToDestoy()
    {
        Object image = _imageQueue.Dequeue();
        Destroy(image);
    }

    public void ToClear()
    {
        if (_imageQueue.Count > 0)
        {
            for (int i = 0; i < _imageQueue.Count; i++)
            {
                Object temp;
                temp = _imageQueue.Dequeue();
                
                Destroy(temp);
            }
        }
    }
}
