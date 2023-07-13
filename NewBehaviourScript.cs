using UnityEngine;

public class myCamControl : MonoBehaviour
{
    public float speed = 2f; // camera move speed
    private bool touch = false; // touching screen or not?
    private Vector2 touchPos; // start touch position

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    touch = true;
                    touchPos = t.position;
                    Debug.Log("Screen Tapped! Start Position: " + touchPos);
                    break;

                case TouchPhase.Moved:

                    if (touch)
                    {
                        Vector2 deltaPos = t.position - touchPos;
                        Debug.Log("Touch Delta: " + deltaPos);
                        MoveCamera(deltaPos);
                    }
                    break;

                case TouchPhase.Ended:
                    touch = false;
                    break;
            }
        }
    }

    // method: move the camera
    private void MoveCamera(Vector2 deltaPos)
    {
        Vector3 movePos = new Vector3(deltaPos.x, 0, deltaPos.y) * speed * Time.deltaTime; // 3D movement vector
        transform.position += movePos; // update camera position
        Debug.Log("Camera Position: " + transform.position);
    }
}
