using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenDestroyDecorator : OutOfScreenTrigger
{
    private IPolledObject _polledObject;
    
    private void Start()
    {
        _polledObject = GetComponent<IPolledObject>();
        onObjectOutOfScreen += Destroy;
    }

    // Update is called once per frame
    private void Destroy(OutOfScreenDirection direction)
    {
        if (_polledObject != null)
            _polledObject.ReturnToPool();
        else Destroy(gameObject);
    }
    
    
}
