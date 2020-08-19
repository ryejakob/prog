using System;
using static System.Math;
using static System.Console;
using static vector;
using static montecarlo;

public class main{
	static int Main(){
	//testing in 1-D: Sin²(x) from 0 to pi 
	//the function: 
/*
	Func<vector,double> f1= (x) => Sin(x[0])*Sin(x[0]);
	
	//start and end points:
	vector a1=new vector(0.0);
	vector b1=new vector(2*PI);
	
	int N1=1000; // number of sampling points
	//calling plainmc
	vector F1=plainmc(f1, a1, b1, N1);

	WriteLine($"Part A");
	WriteLine($"i) testing the method by integrating Sin²(x) from 0 to Pi (analytic result Pi/2)");
	WriteLine($"calulated result {F1[0]},	estimated error: {F1[1]}, 	atual error: {Abs(F1[0]-PI)}	Number of points: {N1}");
	WriteLine($"");
*/
	//test by calculating given function...
	//the function:
	Func<vector,double> f2 = (x) => 1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*1/(Pow(PI,3));
	
	int N2=1000000; // number of sampling points...
	double R=1.3932039296856768591842462603255; // the analytic result

	vector a2= new vector(0.0,0.0,0.0); //start
	vector b2= new vector(PI,PI,PI); //end

	//caling plainmc:
	//vector F2=plainmc(f2,a2,b2,N2);
	vector F2=SSmc(f2,a2,b2,N2);
	
	WriteLine("Part C:");
	WriteLine("The recursive stratified sampling is tested using same integral as in part 1.");
	WriteLine($"Testing the method by integrating (1-Cos(x[0])*Cos(x[1])*Cos(x[2]))^(-1)*Pi^(-3) from (0,0,0) to (pi,pi,pi)");
	WriteLine($"calulated result {F2[0]},	estimated error: {F2[1]}, 	atual error: {Abs(F2[0]-R)}	Number of points: {N2}");
	//WriteLine($"");

	

	return 0;}
}
