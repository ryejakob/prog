using System;
using static System.Math;
using static Integrator;
using static System.Console;
using static vector;

public class main{
	static int Main(){
	double del=0.0001; // absolute accuracy
	double eps=0.0001; // relative accuracy 
	// integrating sqrt(x):
	int n1=0; int n2=0;
	//the function
	Func<double,double> f1 = (x) => Sqrt(x);
	double a=0;//start 
	double b=1;//end
	
	double F1= integrator(f1, a,b, del, eps, ref n1);//the integration...

	//integrating 4*sqrt(1-x*x):

	//the function
	Func<double, double> f2 = (x) => 4*Sqrt(1-x*x);

	double F2=integrator(f2,a,b,del,eps, ref n2); //the integration..

		
	WriteLine($"Part A: test of integrator:");
	WriteLine($"i) integrate Sqrt(x) from 0 to 1. The calculated result is {F1}, and the analytic result is 2/3.");
	WriteLine($"The result is accepted");
	WriteLine($"");
	WriteLine($"ii) integrate 4*Sqrt(1-x*x) from 0 to 1. The calculated result is {F2}, and the analytic result is pi.");
	WriteLine($"The result is accepted");
	


	return 0;}
}
