#pragma strict
var randomNumber:float;
var wait:float=0.7;
var mat=new Material[2];
function Start () {
 
}
 
function Update () {
randomNumber=Random.Range(0.0,100.0);
if(randomNumber>=30.0 && randomNumber<=30.9 &&gameObject.GetComponent(AudioSource).isPlaying==false )
{
lightning();
 
 
}
 
 
}
function lightning()
{
RenderSettings.skybox=mat[1];
gameObject.GetComponent(Light).color=Color.white;
gameObject.GetComponent(Light).intensity=8;
 
yield WaitForSeconds(wait);
RenderSettings.skybox=mat[0];
gameObject.GetComponent(Light).color=Color.red;
gameObject.GetComponent(Light).intensity=0.11;
 
gameObject.GetComponent(AudioSource).Play();
 
 
 
 
}