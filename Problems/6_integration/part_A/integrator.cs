using static System.Math;
using System;
using static vector;
using System.Collections.Generic;

public class Integrator{
	public static double integrator(Func<double, double> f, double a, double b, double del, double eps, ref int n){
		//evaluet the function at the starting inteval:
		double f2=f(a+2*(b-a)/6); double f3=f(a+4*(b-a)/6);
		n=2;	// n is the number of integrand evaluations

		//to reuse points the function calls the atual integrator functions...
		return integr(f, a, b, del, eps, f2,f3, ref n );
		} // end integrator


	//atual integrator:
	public static double integr(Func<double, double> f, double a, double b, double del, double eps, double f2, double f3, ref int n){
	n=n+2;
	//evaluet the function in the new points:
	double f1=f(a+(b-a)/6); double f4=f(a+5*(b-a)/6);
	//calculate the higher order rule (here trapezium):
	double Q=(2*f1+f2+f3+2*f4)*(b-a)/6;
	//calculate the lower order rule (here rectangle):
	double q=(f1+f2+f3+f4)*(b-a)/4;
	
	double tol=del+eps*Abs(Q); //the tolerance 
	double err=Abs(Q-q); //the error

	if(err < tol){ 
		return Q; //if the result is accepted Q is returned...
		} //end if 
	else{ //so apparently a function i C# can call itself... see below...
		double Q1=integr(f, a, (b+a)/2, del/Sqrt(2), eps, f1, f2, ref n); //calling function for the first half
		double Q2=integr(f, (b+a)/2, b, del/Sqrt(2), eps, f3, f4, ref n); 
		return Q1+Q2;
		}; // end else
	} // end integr

	
		


}; //end class 
