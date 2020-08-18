using System;
using static System.Math;
using static System.Console;
using static vector;
using static Roots;
using static rkODE;
using System.Collections.Generic;

public class main{
	static int Main(){

	//an output file for the dataset to make a plot...
	var plot= new System.IO.StreamWriter("plot1.txt");
	for(double i=3; i<10; i=i+0.4) {
		vector ro1=simB(i);
		vector ro2=newB(i);
		plot.WriteLine($"{i}	{ro1[0]}	{ro2[0]}");
		}//end for 
	plot.Close();

	WriteLine($"Part C:");
	WriteLine($"In plotC.svg the convergence of the solution for the simple boundary condition and more precise is plotted. As expected the more precise boundary yields faster convergence to the exat result -1/2.");
	WriteLine($"");
	WriteLine($"");

	return 0;}//end static Main()...


	//method with simple boundary:
	static vector simB(double rmax){
	
	//M as a function of eps:
	Func<vector, vector> Mfun= (x) => new vector(M(x[0], rmax)); 

	//starting point for "newton" 
	vector xst=new vector((-1)*1.0/2.2);

	//new "newton can be used:
	vector fmin=newton(Mfun, xst, 1e-3);

	return fmin;
	}//end simB
	
	//method with new boundary f(r-> inf)= r*exp(-kr), with k=sqrt(-2*eps)...
	static vector newB(double rmax){
	
	//now M as a function looks like:
	Func<vector, vector> Mfun = (x) => {
		double boundry = rmax*Exp(-Sqrt(-2*x[0])*rmax);
		return new vector(M(x[0], rmax)-boundry);
		};//end Mfun

	//starting point for "newton" 
	vector xst=new vector((-1)*1.0/2.2);

	//new "newton can be used:
	vector fmin=newton(Mfun, xst, 1e-3);

	return fmin;
	}//end newB
	
	//Im asked to a define M(eps)=F(eps,rmax)... for rmax=8 
	static double M(double eps, double rmax){
	//double rmax=8; //Bohr radius...
	//using my ode...
	
	double acc=1e-3; double ep=1e-3; //accuracy
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
