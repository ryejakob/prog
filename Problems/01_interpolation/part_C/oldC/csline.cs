using System;
using static System.Math;
using static vector;

public class cspline {

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

//cubic spline
vector x1,y1,b,c,d;
//constructor 
public cspline(vector x, vector y){
	int m=x.size;	
	x1=x;
	y1=y;
	vector del_x= new vector(m -1);
	vector p= new vector(m-1);
		for(int n=0; n<m-1; n++){
		del_x[n]=x1[n+1]-x1[n];
		p[n]=(y[n+1]-y[n])/del_x[n];		
		}//end for
	vector D= new vector(m);
	D[0]=2; D[m-1]=2;
	vector Q=new vector(m-1);
	Q[0]=1;
	vector B= new vector(m);
	B[0]=3*p[0]; B[m-1]=3*p[m-2];
		for(int n1=0; n1<m-2; n1++){
		D[n1+1]=2*del_x[n1]/del_x[n1+1]+2;
		Q[n1+1]=del_x[n1]/del_x[n1+1];
		B[n1+1]=3*(p[n1]+p[n1+1]*del_x[n1])/del_x[n1+1];
		}//end for
		
		//changing D and B to the system after gauss elemination ...
		for(int n2=1; n2<m; n2++){
		D[n2]=D[n2]-Q[n2-1]/D[n2-1];
		B[n2]=B[n2]-B[n2-1]/D[n2-1];
		}//end for

	//back substitution...
	b=new vector(m);
	b[m-1]=B[m-1]/D[m-1];
		for(int n3=m-2; n3>=0; n3--){
		b[n3]=(B[n3]-Q[n3]*b[n3+1])/D[n3];
		}//end for

	//find c and d from b...
	c=new vector(m-1);
	d=new vector(m-1) ;
		for(int n4=0; n4<m-1; n4++){
		c[n4]=(3*p[n4]-2*b[n4]-b[n4+1])/del_x[n4];
		d[n4]=(b[n4]+b[n4+1]-2*p[n4])/Pow(del_x[n4],2);
		}//end for
	}// end constu

public double c_spline(double z){
	int i=binsearch(x1,z);
	return y1[i]+b[i]*(z-x1[i])+c[i]*Pow(z-x1[i],2)+d[i]*Pow(z-x1[i],3);
	}

public double cderivative(double z){
	int i=binsearch(x1,z);
	return b[i]+2*c[i]*(z-x1[i])+3*d[i]*Pow(z-x1[i],2);
	}

public double cintegral(double z){
	int i=binsearch(x1,z);
	double s_sum=0;
		for(int n=0; n<i; n++){
		s_sum=s_sum+y1[n]*(x1[n+1]-x1[n])+1/2*b[n]*Pow(x1[n+1]-x1[n],2)+ 1/3*c[n]*Pow(x1[n+1]-x1[n],3)+1/4*d[n]*Pow(x1[n+1]-x1[n],4);
		}//end for
	return s_sum+y1[i]*(z-x1[i])+1/2*b[i]*Pow(z-x1[i],2)+ 1/3*c[i]*Pow(z-x1[i],3) +1/4*d[i]*Pow(z-x1[i],4);
	}
//end cubic spline

//old code (but working) code of linear and q-spline
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

// end quadratic-spline

}// end class 
