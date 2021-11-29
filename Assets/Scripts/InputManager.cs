using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
    [Inject] private Snake _snake;


    void Update()
    {
        DesktopInput();
        TouchInput();
    }

    void DesktopInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _snake.Move(Vector3.left, false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _snake.Move(Vector3.right, false);
        }
    }
    void TouchInput()
    {
        if (Input.touches.Length > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    var currentX = _snake.transform.position.x;
                    var targetX = raycastHit.point.x;

                    targetX = Mathf.Clamp(targetX, -_snake.TurningSector, _snake.TurningSector);
                    var direction = new Vector3(targetX - currentX, 0, 0);
                    _snake.Move(direction, false);
                }
            }
        }
    }
}
