using System;
using static System.Math;
using static vector;

public class interpol{

// binary search
public static int binsearch(vector x, double z)
	{/* locates the interval for z by bisection */ 
	int i=0, j=x.size-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

// Linear spline 

public static double linterp(vector x, vector y, double z){
	int i=binsearch(x,z);
	double p=(y[i+1]-y[i])/(x[i+1]-x[i]);
	return y[i]+p*(z-x[i]);
	}

//integral from x[0] to z
public static double linterpInteg(vector x, vector y, double z){
	int i=binsearch(x,z);
	double p=(y[i+1]-y[i])/(x[i+1]-x[i]),S_sum=0;
	for(int n=0; n<i; n++){
		double p1=(y[n+1]-y[n])/(x[n+1]-x[n]);
		S_sum=S_sum+y[n]*(x[n+1]-x[n])+p1*(0.5*Pow(x[n+1],2)-x[n]*x[n+1]+0.5*Pow(x[n],2));
		}
	
	return S_sum+y[i]*(z-x[i])+p*(0.5*Pow(z,2)-x[i]*z+0.5*Pow(x[i],2));
	}

}


