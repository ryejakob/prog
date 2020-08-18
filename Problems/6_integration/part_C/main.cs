using System;
using static System.Math;
using static Integrator;
using static System.Console;
using static vector;
using static quad;

public class main{
	static int Main(){

	double pINF = double.PositiveInfinity;
	double nINF = double.NegativeInfinity;	
	//test of cc-integrator
	//test functions:
	Func<double,double> f1 = (x) => Pow(Sin(x),4)/(Pow(x,4));
	Func<double,double> f2 = (x) => Exp(-x*x); 	

	//number of evaluations:
	int n1=0; int n2=0; int n1o=0; int n2o=0; 
	double del=0.0001; double eps=0.0001;

	vector R1=INFin(f1, 0, pINF, del,eps, ref n1);
	vector R2=INFin(f2, nINF, pINF, del,eps, ref n2);

	//o8av:
	//to find the number of eval used in o8av you can use following trick:
	Func<double, double> f3 = (z) => {n1o++; return f1(z); };
	double R1o = o8av(f3, 0,pINF,  del, eps);
	Func<double, double> f4 = (z) => {n2o++; return f2(z); };
	double R2o = o8av(f4, nINF,pINF,  del, eps);

	WriteLine($"Part C:");
	WriteLine($"Test of infinite integrator. I set delta=epsilon=0.0001");
		WriteLine($"i) test function: Sin⁴(x)/x⁴ from 0 to Infinety. Table value Pi/3.");
	WriteLine($"My integrator gave the result {R1[0]}, using {n1} evaluations. Estimated error {R1[1]}, atual error {R1[0]-PI/3}");
	WriteLine($"o8av gave the result {R1o}, using {n1o} evaluations.");
	WriteLine($"");

	WriteLine($"ii) test function: Exp(-x*x) from -infinity to Infinety. Table value sqrt(pi).");
	WriteLine($"My integrator gave the result {R2[0]}, using {n2} evaluations. Estimated error {R2[1]}, atual error {R2[0]-Sqrt(PI)}");
	WriteLine($"o8av gave the result {R2o}, using {n2o} evaluations.");
	WriteLine($"");


	return 0;}
}
