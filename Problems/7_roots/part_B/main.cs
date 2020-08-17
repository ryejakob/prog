using System;
using static System.Math;
using static System.Console;
using static vector;
using static Roots;
using static rkODE;
using System.Collections.Generic;

public class main{
	static int Main(){

	//M as a function of eps:
	Func<vector, vector> Mfun= (x) => new vector(M(x[0])); 

	//starting point for "newton" 
	vector xst=new vector((-1)*1.0/2.0);

	//new "newton can be used:
	vector fmin=newton(Mfun, xst, 1e-5);

	WriteLine($"Part B:");
	WriteLine($"Calculated lowest root of M(eps) is {fmin[0]}");
	WriteLine($"In plot.svg the the resulting function is plotted with the exact result.");

	//jakob skriv noget tekst til {fmin[0]}...
	
	//I need to plot the function with the calculated eps, so I define the function:
	Func<double,vector,vector> fun1 = (r,f) => new vector(f[1], (-2)*fmin[0]*f[0]-2*f[0]/r);
	
	
	// to use ode I define:
	double acc=1e-5; double ep=1e-5; //accuracy
	double h=0.01; //step size
	vector vst=new vector(acc-acc*acc, 1-2*acc); //starting point
	double rmax=8; //Bohr radius...

	//lists: 
	List<double> tl= new List<double>(); List<vector> yl= new List<vector>();

	//using ode:
	int st=driver12(fun1,acc, vst, rmax, h, acc, ep, tl, yl);

	//an output file for the dataset to make a plot...
	var plot= new System.IO.StreamWriter("plot1.txt");
	for(int i=0; i<tl.Count; i++) {
		plot.WriteLine($"{tl[i]} {yl[i][0]}");
		}//end for 

	//new output for analytic result f(r)=r*exp(-r)
	var plot2= new System.IO.StreamWriter("plot2.txt");
	for(double r=0; r <= 8; r=r+0.01){
		plot2.WriteLine($"{r} {r*Exp(-r)}");
		}//end for



	return 0;}//end static Main()...
	
	//Im asked to a define M(eps)=F(eps,rmax)... for rmax=8 
	static double M(double eps){
	double rmax=8; //Bohr radius...
	//using my ode...
	
	double acc=1e-5; double ep=1e-5; //accuracy
	double h=0.01; //step size
	
	// the starting vector: the condision f(r->0)= r-r² yeilds f'(r->0)=1-2r. Lets start at 0+acc...
	vector vst=new vector(acc-acc*acc, 1-2*acc);
	
	//the function:
	Func<double,vector,vector> fun = (r,f) => new vector(f[1], (-2)*eps*f[0]-2*f[0]/r);

	//lists: 
	List<double> tl= new List<double>(); List<vector> yl= new List<vector>();

	//using ode:
	int st=driver12(fun,acc, vst, rmax, h, acc, ep, tl, yl);

	//return end point f(0)
	return yl[yl.Count-1][0];
	}//end M 
	


}
