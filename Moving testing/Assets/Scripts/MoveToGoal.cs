
using UnityEngine;

public class MoveToGoal : MonoBehaviour {

	[SerializeField] float speed = 2.0f;
	[SerializeField] float accuracy = 0.01f;
	[SerializeField] Transform goal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.LookAt(goal.position);
		Vector3 direction = goal.position - this.transform.position;
		Debug.DrawRay(this.transform.position,direction,Color.red);
		if(direction.magnitude > accuracy)
			this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
			/*
				Space.World because if it translated locally (remember that local x,y,z are different to world x,y,z).
				accuracy because no matter how hard you try, it is nearly impossible for the character to arrive exactly on top of the goal
				
				
				And let us say you put direction instead of direction.normalized, then the character will start of super fast in the 
				beginning and then go very slowly to the goal but never reach it, kinda like the e^-x graph because the value keeps on 
				becoming smaller and smaller till it is negligible but you are still adding it and hence infinite addition. 
			*/
	}
}
