using System;
using static System.Math;
using static vector;

public class Akima{

	//fields:
	public readonly vector a;
	public readonly vector b;
	public readonly vector c;
	public readonly vector d;
	public readonly vector x;

	//constructor:
	public Akima(vector x, vector y, vector dA1=null, vector dA2=null, vector dAn1=null, vector dAn=null){
	if(x.size != y.size){ //Make sure x and y is the same size
		int n1;
		if(x.size<y.size){ 
			n1=x.size; 
			this.a=new vector(n1);
			for(int i=0; i<n1; i++){
				this.a[i]=y[i];
				}//end for	
			}//end if
		else{ 
			n1=y.size;
			this.x=new vector(n1);
			for(int i=0; i<n1; i++){
				this.x[i]=x[i];
				}//end for
			}//end else
		Console.Error.WriteLine($"Error: input vectors in Akima must have the same size! The first {n1}-elements of the input vectors was used.");
		}//end if
	else{
	this.x=x;
	this.a=y;
	}

	if(1==a.size){//if input have size the input point is returned as spline 
	Console.Error.WriteLine($"Error: input vector have size 1!");
	this.b=new vector(0.0);
	this.c=new vector(0.0);
	this.d=new vector(0.0);
	}//end if 
	else if(2==a.size){//if input is two points a line between them is returned
	Console.Error.WriteLine($"Error: input vector have size 2! Must be at least 3!");
	double p=(a[1]-a[0])/(x[1]-x[0]);
	this.b=new vector(1);
	b[0]=p;
	this.c=new vector(0.0);
	this.d=new vector(0.0);
	}//end else if 
	else{
	
	this.b=new vector(a.size);
	this.c=new vector(a.size-1);
	this.d=new vector(a.size-1);
	
	//calculating deltax and p (note delta y is never used directly):
	//the for-loop also define a from y
	vector delx=new vector(a.size-1);
	vector p=new vector(a.size-1);
	for(int i=0; i<p.size; i++){
		a[i]=y[i];
		delx[i]=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/delx[i];
		}//end for
	
	//calculating b.i= A.i'
	//if no value is given for A.1',A.2', A.(N-1)' and A.N' the values is set	
	

	if(dA1==null){
		b[0]=p[0];
		}//end if
	else{
		b[0]=dA1[0];
		}//end else
	if(dA2==null){
		b[1]=b[0]/2+p[1]/2;
		}//end if 
	else{
		b[1]=dA2[0];
		}//end else
	if(dAn==null){
		b[a.size-1]=p[a.size-2];
		}//end if
	else{
		b[a.size-1]=dAn[0];
		}//end else
	if(dAn1==null){
		b[a.size-2]=b[a.size-1]/2+p[a.size-3]/2;
		}//end if
	else{
		b[a.size-2]=dAn1[0];
		}//end else
	
	
	
	//for-loop to calculate the rest of the b-values
	for(int i=2; i<(a.size-2); i++){
		double wp=Abs(p[i+1]-p[i]);
		double wm=Abs(p[i-1]-p[i-2]);
		if(0==(wp+wm)){
			b[i]=(p[i-1]+p[i])/2;
			}//end if
		else{
			b[i]=(wp*p[i-1]+wm*p[i])/(wm+wp);
			}//end else
		}//end for
	//now c and d can be calculated: 
	for(int i=0; i<p.size; i++){
		c[i]=(3*p[i]-2*b[i]-b[i+1])/delx[i];
		d[i]=(b[i]+b[i+1]-2*p[i])/(delx[i]*delx[i]);
		}//end for
	
	}//end else
	}//end constructor

	//binary search (taken from Problem 1)
	public static int binsearch(vector x, double z)
	{/* locates the interval for z by bisection */ 
	int i=0, j=x.size-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

	//method that given a double x returns A(x)...
	public double spline(double x1){
	if((x1<x[0]) && (x1>x[a.size-1])){
		Console.Error.WriteLine($"Error input out of bound");
		return 0;
		}//end if 
	else{
		int k=binsearch(x,x1);
		double Ax=a[k]+b[k]*(x1-x[k])+c[k]*Pow(x1-x[k],2)+d[k]*Pow(x1-x[k],3);
		return Ax;
		}//end else
	}//end spline
	
	//calculate the derivative at a given point:
	public double derivative(double x1){
	if((x1<x[0]) && (x1>x[a.size-1])){
		Console.Error.WriteLine($"Error input out of bound");
		return 0;
		}//end if 
	else{
		int k=binsearch(x,x1);
		double Ax=b[k]+2*c[k]*(x1-x[k])+3*d[k]*Pow(x1-x[k],2);
		return Ax;
		}//end else
	}//end derivative

	//calculate the anti-derivative at a given point:
	public double integral(double x1){
	if((x1<x[0]) && (x1>x[a.size-1])){
		Console.Error.WriteLine($"Error input out of bound");
		return 0;
		}//end if 
	else{
		int k=binsearch(x,x1);
		double sum=0;
		for(int j=0; j<k;j++){
			sum=sum+a[j]*(x[j+1]-x[j])+b[j]/2*Pow(x[j+1]-x[j],2)+c[j]/3*Pow(x[j+1]-x[j],3)+d[j]/4*Pow(x[j+1]-x[j],4);
			}//end for
		return sum+a[k]*(x1-x[k])+b[k]/2*Pow(x1-x[k],2)+c[k]/3*Pow(x1-x[k],3)+d[k]/4*Pow(x1-x[k],4);
		}//end else
	}//end anti-derivative	



}// end class
