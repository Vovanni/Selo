using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Box_Sc : MonoBehaviour
{

    public Animator animator;
	public AudioClip impact;
	AudioSource audio;
    private float v = 0;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        v = UnityStandardAssets.Vehicles.Car.CarUserControl.v;
        animator.SetFloat("Ver", v);
        if (v == 0.0f) animator.SetBool("Not", true);
        else animator.SetBool("Not", false);
    }

	public void Dwn () {
		audio.PlayOneShot(impact, 1);
	}
	public void Up () {
		audio.PlayOneShot(impact, 1);
	}
}

