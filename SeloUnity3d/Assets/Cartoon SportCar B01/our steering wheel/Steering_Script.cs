using UnityEngine;

public class Steering_Script : MonoBehaviour
{

    public Animator animator;
	private float h = 0;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void  Update()
    {
        h = UnityStandardAssets.Vehicles.Car.CarUserControl.h;
        animator.SetFloat("Hor", h);
        if (h==0.0f) animator.SetBool("Not", true);
        else animator.SetBool("Not", false);

    }
    }

