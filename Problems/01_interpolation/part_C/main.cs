using System;
using static System.Console;
using static System.Math;
using static vector;
using static cspline;


class main{
	static int Main() {

	
	
	//test of  cubicspline using Sin(x)

	int n=11; //number of sample points

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
	
	cspline csin=new cspline(x,y);

	//generating data to plot
	var data=new System.IO.StreamWriter("data.txt");
	int N=100;
	for(int i=0; i<N; i++){
		double xn=2*i*(PI/(N-1));
		data.WriteLine($"{xn} {Sin(xn)} {csin.c_spline(xn)} {Cos(xn)} {csin.cderivative(xn)} {1-Cos(xn)} {csin.cintegral(xn)}");
		}//end for 
	data.Close();

	//end of test using sine

	WriteLine($"Part C:");
	WriteLine($"Cubic spline of Sin(x) can be seen in cubic_splineC.svg.");
	WriteLine($"The derivative of the aforementioned spline of can be seen in cubic_derivativeC.svg, and the integral in cubic_integralC.svg");
	WriteLine($"In comparisonC.svg my the calculated cubic spline is compared with spline from plotutils");
	
		
		
	
		

			

	return 0;}
}
