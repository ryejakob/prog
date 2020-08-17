using System;
using static System.Console;
using static System.Math;
using static vector;
using static qspline;


class main{
	static int Main() {
	
	//test of qspline using Sin(x)

	int n=9; //number of sample points

	//generate sample points:
	vector x=new vector(n);
	vector y=new vector(n);
	var points=new System.IO.StreamWriter("points.txt");
	for(int i=0; i<n;i++){
		x[i]=2*i*(PI/(n-1));
		y[i]=Sin(x[i]);
		points.WriteLine($"{x[i]} {y[i]}");
		}//end for
	points.Close();

	//using qspline
	
	qspline qsin=new qspline(x,y);

	//generating data to plot
	var data=new System.IO.StreamWriter("data.txt");
	int N=100;
	for(int i=0; i<N; i++){
		double xn=2*i*(PI/(N-1));
		data.WriteLine($"{xn} {Sin(xn)} {qsin.spline(xn)} {Cos(xn)} {qsin.derivative(xn)} {1-Cos(xn)} {qsin.integral(xn)}");
		}//end for 
	data.Close();

	//end of test using sine

	WriteLine($"Part B:");
	WriteLine($"Quadratic spline of Sin(x) can be seen in quadratic_splineB.svg.");
	WriteLine($"The derivative of the aforementioned spline of can be seen in quadratic_derivativeB.svg, and the integral in quadratic_integralB.svg");
	
		
		
	
		

			

	return 0;}
}
