using UnityEngine;

public class objAnimControl : MonoBehaviour
{
    private Animator anim;
    private bool drag = false;
    private Vector2 dragPos;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse down method");
        anim.SetBool("isPushed", true);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    drag = true;
                    dragPos = t.position;
                    Debug.Log("Screen Tapped! Start Position: " + dragPos);
                    anim.SetBool("isPushed", true);
                    break;

                case TouchPhase.Ended:
                    anim.SetBool("isPushed", false);
                    drag = false;
                    break;
            }
        }
    }
}


