using System;
using static System.Math;
using static vector;
using static matrix;
using static gram_s;


public class Roots{
	//function to find roots of f. x is the start guess..
	public static vector newton(Func<vector,vector> f, vector x, double eps=1e-3, double dx=1e-7){
	bool seed2=true;
	while(seed2){
	//seed2=false;
	//First the jacobian matrix J is calculated:
	vector fx=f(x);
	matrix J = new matrix(x.size,x.size);
	for(int k=0; k<x.size; k++){ // for-loop over vector x
		x[k]=x[k]+dx; //change x 
		vector df=(f(x)-fx)/dx; // the differnce in f(x)
		for(int i=0; i<x.size; i++){ 
			J[i, k]=df[i]; // calculate the matrix element
			} //end for
		x[k]=x[k]-dx; // reset x
		} // end for 
	
	// solving J*DX=-f(x) 
	gram_s GJ= new gram_s(J);
	vector Dx= GJ.solve((-1)*fx); // using my own method to solve the equation ...

	//calculating the step size s
	double s=2;
	bool seed1=true;
	while(seed1){
		s=s/2;
		if((f(x+s*Dx).norm() < (1-s/2)*f(x).norm() ) && (s < 1.0/64)){
			seed1=false;
			}//end if
		}//end while
	
	x=x+s*Dx; //calculate the new x!

	//if((Dx.norm()<dx) && (f(x).norm() < eps)){
	if(Dx.norm() < dx){
		seed2=false;
		}//end if
	else if(f(x).norm() < eps){
		seed2=false;
		}//end else if
	
	//seed2=false;
	}//end while
	return x;
	}//end newton...
	


}// end class
