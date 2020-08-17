using System;
using static System.Console;
using static System.Math;
using static vector;
using static interpol;


class main{
	static int Main() {

	//test of linear spline using Sin(x)

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

	//generating data to plot
	var data=new System.IO.StreamWriter("data.txt");
	int N=100;
	for(int i=0; i<N; i++){
		double x1=2*i*(PI/(N-1));
		data.WriteLine($"{x1} {Sin(x1)} {linterp(x,y,x1)} {1-Cos(x1)} {linterpInteg(x,y,x1)}");
		}//end for 
	data.Close();

	WriteLine($"Part A:");
	WriteLine($"Linear spline of Sin(x) can be seen in Linear_splineA.svg.");
	WriteLine($"Linear spline integral of Sin(x) can be seen in Linear_integralA.svg.");
		
		
		
		

			

	return 0;}
}
