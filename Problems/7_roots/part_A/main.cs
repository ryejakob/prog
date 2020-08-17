using System;
using static System.Math;
using static System.Console;
using static vector;
using static Roots;

public class main{
	static int Main(){
	//test of "newton" using Cos²(x) (root at Pi/2)
	
	//fuction:
	Func<vector,vector> f1= (x) => new vector(Cos(x[0])*Cos(x[0]));
	// starting point
	vector x1= new vector(1.2);
	//using "newton":
	vector R1=newton(f1,x1,1e-5);
	
	WriteLine($"Part A:");
	WriteLine($"i) Test of simple root finding using Cos²(x) (here epsilon used was 1e-5: )");
	WriteLine($"Analytic value Pi/2={PI/2},	calculated value: {R1[0]}");
	WriteLine($"");
	
	//test of "newton" using Rosenbrock: f(x,y)=(1-x)²+100(y-x²)²
	// the gradient of f(x,y):
	Func<vector,vector> f2= (x) => new vector((-2)*(1-x[0])+400*x[0]*(x[1]-x[0]*x[0]), 200*(x[1]-x[0]*x[0]));
	
	//starting point:
	vector x2= new vector(0.7,1.2);
	
	//using "newton":
	vector R2=newton(f2,x2);

	WriteLine($"ii) Finding min i Rosenbrock");
	WriteLine($"Analytric solution is (1,1) the calculated result is: 	({R2[0]},{R2[1]})");


	return 0;}
}
