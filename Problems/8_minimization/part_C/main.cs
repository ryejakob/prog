using System;
using static System.Math;
using static System.Console;
using static vector;
using static qNewton;

public class main{
	static int Main() {
	
	//test function: Rosenbrock
	Func<vector,double> f1= (x) => Pow(1-x[0],2)+100*Pow(x[1]-x[0]*x[0],2);
	vector x1= new vector(2,3); //stating point
	int nr1 =0; //steps; 
	int nr1d =0; //steps;
	double eps1=1e-5; //accuracy
	//using qnewton:
	vector min1=qnewton(f1,x1,eps1, ref nr1);
	//using downhill
	vector min1d=downhill2(f1, x1, eps1, ref nr1);




	WriteLine($"Part C:");
	WriteLine($"i)Test of simplex on Rosenbrock valley function");
	WriteLine($"The analytic value for the minimum is (1,1).");
	WriteLine($"The calculated minimum is ({min1d[0]}, {min1d[1]})).");
	WriteLine($"The starting point was (2,3), the accuracy eps={eps1} and the number of iterations {nr1d}. To comparison the qnewton method used {nr1} steps.");
	WriteLine($"");
	//testing Himmelblau's function
	//the function:
	Func<vector,double> f2= (x) => Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7,2);

	//looking for the minimum (3,2)
	vector xst2=new vector(2.5,4);

	int nr2=0;int nr2d=0;// steps
	//using qnewton:
	vector min2=qnewton(f2,xst2,eps1, ref nr2);
	//using downhill.
	vector min2d=downhill2(f2, xst2,eps1, ref nr2d);

	WriteLine($"ii) test of simplex on Himmelblau's function");
	WriteLine($"The analytic value for the minimum is (3.584428, -1.848126).");
	WriteLine($"The calculated minimum is ({min2d[0]}, {min2d[1]})).");
	WriteLine($"The starting point was (2.5,4), the accuracy eps={eps1} and the number of iterations {nr2d}. To comparison the qnewton method used {nr2} iterations.");
	
	


	return 0;}




}
