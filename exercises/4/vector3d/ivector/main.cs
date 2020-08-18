using static System.Console;
class main{
static void Main(){
	vector3d u=new vector3d(1,2,3);

	double d=ivector3dfunctions.dot(u,u);
	WriteLine($"test of dot function calleds using iterface dot(u,u)={d}, with u=(1,2,3)");
}
}
