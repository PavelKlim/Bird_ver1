var smoothTimex = 0.5;
var smoothTimey = 0.01;
var target : Transform;
private var thisTransform : Transform;
private var velocity : Vector2;
//private var i : int;
//private var array : float [] ;

function Start()
{
 
 thisTransform = transform;
 /*
 i=0;
 array[i]=target.position.y;
 */
}

function FixedUpdate() 
{
	//i=i+1;
 //array[i]=target.position.y;
 thisTransform.position.x = Mathf.SmoothDamp( thisTransform.position.x,target.position.x, velocity.x, smoothTimex);
 //thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y,target.position.y, velocity.y, smoothTimey);
 /* if( array[i-1]<array[i] ) thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y,target.position.y+2.2, velocity.y, smoothTimey);
  else	
  		if( array[i-1] > array[i] ) thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y,target.position.y+2.2, velocity.y, 0.1);*/
	//thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y,target.position.y+2.2, velocity.y, smoothTimey);
}