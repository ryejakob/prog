using System;
using static System.Math;
using static rkODE;
using static System.Console;
using System.Collections.Generic;
using static vector;

public class main{
	static int Main(){
	// rk12 will be used to examin the diff. eq. u''=-u (the solution is cos)...
	double a=0; double b=2*PI; // start and end points
	double h=0.01; //step size
	double acc=0.0001; double eps=0.0001; // accurecy ...
	
	//Lists:
	List<double> tl = new List<double>();
	List<vector> yl = new List<vector>(); 

	//the function:
	Func<double, vector, vector> f = (t, y) => new vector(y[1], -y[0]);

	// the function values at a...
	vector yst= new vector(0.0, 1.0);

	//using the rutine 
	int st= driver12(f, a, yst, b, h,  acc,  eps, tl, yl);	

	//making output for plot:
	var plot=new System.IO.StreamWriter("plot.txt");
	for(int i=0; i< tl.Count; i++){
		plot.WriteLine($" {tl[i]}  {yl[i][0]}  {yl[i][1]}  {Sin(tl[i])}  {Cos(tl[i])}");
		}//end for
	plot.Close();

	WriteLine("Part A:");
	WriteLine("I have implemented the midpoint-Euler method. The method has been tested on the system u''=-u");
	WriteLine("In PlotA.svg the calculated solution is seen with Sin(t) and Cos(t) (the analytic solution)");



	return 0;}
}
