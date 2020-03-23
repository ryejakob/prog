using System;
using static System.Math;
using static vector;

public class qspline {

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

public static double linterpInteg(vector x, vector y, double z){
	int i=binsearch(x,z);
	double p=(y[i+1]-y[i])/(x[i+1]-x[i]),S_sum=0;
	for(int n=0; n<i; n++){
		double p1=(y[n+1]-y[n])/(x[n+1]-x[n]);
		S_sum=S_sum+y[n]*(x[n+1]-x[n])+p1*(0.5*Pow(x[n+1],2)-x[n]*x[n+1]+0.5*Pow(x[n],2));
		}
	
	return S_sum+y[i]*(z-x[i])+p*(0.5*Pow(z,2)-x[i]*z+0.5*Pow(x[i],2));
	}


// quadratic-spline

public static vector qsplineC(vector x, vector y){
	int lenght=x.size;
	int lenght_red=lenght-1;
	vector c = new vector(lenght);
	vector del_x=new vector(lenght-1);
	vector p=new vector(lenght-1);
	c[0]= 0;
	for(int n=0; n<lenght_red; n++){
		del_x[n]=x[n+1]-x[n];
		p[n]=(y[n+1]-y[n])/del_x[n];
		}
	for(int n=0; n<lenght_red-1; n++){
		c[n+1]=1/del_x[n+1]*(p[n+1]-p[n]-c[n]*del_x[n]);
		}
	return c;
}

public static vector qsplineB(vector x, vector y){
	int lenght=x.size;
	//int lenght_red=lenght-2;
	vector b = new vector(lenght-1);
	vector c = qsplineC(x,y);
	for(int n=0; n<(lenght-1); n++){
		double del_x=x[n+1]-x[n];
		double p=(y[n+1]-y[n])/del_x;
		b[n]=p-c[n]*del_x;
		}
	return b;
}
public static double q_spline(vector x, vector y, double z){
	int i=binsearch(x,z);
	vector b = qsplineB(x,y);
	vector c = qsplineC(x,y);
	double s=y[i]+b[i]*(z-x[i])+c[i]*Pow(z-x[i],2);
	return s;	
	}
public static double qderivative(vector x, vector y, double z){
	int i=binsearch(x,z);
	vector b = qsplineB(x,y);
	vector c = qsplineC(x,y);
	double ds=b[i]+2*c[i]*(z-x[i]);
	return ds;
	}
public static double qintegral(vector x, vector y, double z){
	int i=binsearch(x,z);
	vector b = qsplineB(x,y);
	vector c = qsplineC(x,y);
	double s_sum=0;
	for(int n=0; n<i; n++){
		double del_x=x[n+1]-x[n];
		s_sum=s_sum+y[n]*del_x+0.5*b[n]*Pow(del_x,2)+1/3*c[n]*Pow(del_x,3);
		}
	double del_z=z-x[i];
	return s_sum+y[i]*del_z+0.5*b[i]*Pow(del_z,2)+1/3*c[i]*Pow(del_z,3);
	}

}
