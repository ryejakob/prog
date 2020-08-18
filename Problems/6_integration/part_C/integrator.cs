using static System.Math;
using System;
using static vector;
using static System.Double;
using System.Collections.Generic;

public class Integrator{
	public static vector integrator(Func<double, double> f, double a, double b, double del, double eps, ref int n){
		//evaluet the function at the starting inteval:
		double f2=f(a+2*(b-a)/6); double f3=f(a+4*(b-a)/6);
		n=2;	// n is the number of integrand evaluations

		//to reuse points the function calls the atual integrator functions...
		return integr(f, a, b, del, eps, f2,f3, ref n );
		} // end integrator


	//atual integrator:
	public static vector integr(Func<double, double> f, double a, double b, double del, double eps, double f2, double f3, ref int n){
	n=n+2;
	//evaluet the function in the new points:
	double f1=f(a+(b-a)/6); double f4=f(a+5*(b-a)/6);
	//calculate the higher order rule (here trapezium):
	double Q=(2*f1+f2+f3+2*f4)*(b-a)/6;
	//calculate the lower order rule (here rectangle):
	double q=(f1+f2+f3+f4)*(b-a)/4;
	
	double tol=del+eps*Abs(Q); //the tolerance 
	double err=Abs(Q-q); //the error
	//vector to return...
	vector vec= new vector(2);
	

	if(err < tol){ 
		vec[0]=Q;
		vec[1]=err;
		return vec; //if the result is accepted Q is returned...
		} //end if 
	else{ //so apparently a function i C# can call itself... see below...
		vector Q1=integr(f, a, (b+a)/2, del/Sqrt(2), eps, f1, f2, ref n); //calling function for the first half
		vector Q2=integr(f, (b+a)/2, b, del/Sqrt(2), eps, f3, f4, ref n); 
		vec[0]=Q1[0]+Q2[0];
		vec[1]=Q1[1]+Q2[1];
		return vec;
		}; // end else
	} // end integr


	//the Clenshaw-Curtis variable transformation:
	public static vector CCin(Func<double, double> f, double a, double b, double del, double eps, ref int n){

	// First step is to use the linear transformation: x => u(x)=(b-a)x/2+(a+b)/2 so the integral now is over f((b-a)x/2+(a+b)/2)*(b-a)/2 from -1 to 1. Then the Clenshow-Curtis transform is used as desribed in the lecture notes to get the integral f((b-a)*Cos(x)/2+(a+b)/2)*(b-a)*Sin(x)/2:

	Func<double, double> f1 = (x) => f((b-a)*Cos(x)/2+(a+b)/2)*(b-a)*Sin(x)/2;
	
	return integrator(f1, 0,PI, del, eps, ref n);
	} //end CCin
		
	//infinity limits:
	public static vector INFin(Func<double, double> f, double a, double b, double del, double eps, ref int n){
	if(a>b){
		vector vec= INFin(f,a,b,del,eps,ref n);
		vec[0]=-vec[0];
		vec[1]=-vec[1];
		return vec;
		}; //end if
	if(IsNegativeInfinity(a) && IsInfinity(b)){
		return integrator((t)=>f(t/(1-t*t))*(1+t*t)/((1-t*t)*(1-t*t)), -1, 1, del, eps, ref n);
		}; //end if 
	if(!IsNegativeInfinity(a) && IsInfinity(b)){
		return integrator( (t)=>f(a+(1-t)/t)/(t*t), 0, 1, del, eps, ref n);
		};//end if
	if(IsNegativeInfinity(a) && !IsInfinity(b)){
		return integrator( (t)=>f(b-(1-t)/t)/(t*t), 0, 1, del, eps, ref n);
		}; //end if
	return INFin(f,a,b,del,eps,ref n);
	} //end INFin
	




}; //end class 
