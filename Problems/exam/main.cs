using System;
using static System.Math;
using static System.Console;
using static vector;
using static Akima;
using static cspline;

public class main{
	static int Main(){
	//test with sin(x)
	int n=7;
	
	vector x=new vector(n);
	vector y=new vector(n);
	for(int i=0; i<n; i++){
		x[i]=2*i*(PI/(n-1));
		y[i]=Sin(x[i]);
		}//end for
	
	
	Akima AA=new Akima(x,y);

	//outfile for the points given to Akima
	var sinp= new System.IO.StreamWriter("sinp.txt");
	for(int k=0; k<n; k++){
		sinp.WriteLine($"{x[k]}  {y[k]}");
		}//end for
	sinp.Close();

	//outfile for data for sin(x) and it's derivative and anti-derivativ
	var sind=new System.IO.StreamWriter("sindata.txt");
	int N=100;
	for(int i=0; i<N;i++){
		double xnew=2*i*(PI/(N-1));
		sind.WriteLine($"{xnew}  {Sin(xnew)}  {AA.spline(xnew)} {Cos(xnew)} {AA.derivative(xnew)} {1-Cos(xnew)} {AA.integral(xnew)} ");
		}//end for
	sind.Close();

	//test using f2=O(x-1)-O(x-2) where O is the unity step function
	//step function
	Func<double, double> O = (z) => {if(z<0){return 0;}else{return 1;}};
	int n2=11;
	
	//generate generation-points:
	vector x2=new vector(n2);
	vector y2=new vector(n2);
	var stepp=new System.IO.StreamWriter("stepp.txt");
	for(int i=0; i<n2; i++){
		x2[i]=(3.0/(n2-1))*i;
		y2[i]=O(x2[i]-1)-O(x2[i]-2);
		stepp.WriteLine($"{x2[i]} {y2[i]}");
		}//end for
	stepp.Close();
	
	//akima on f2
	Akima Af2=new Akima(x2,y2, new vector(0.0));

	//cubic spline on f2
	cspline Cf2= new cspline(x2,y2);

	//data to plot of step function
	var step=new System.IO.StreamWriter("stepdata.txt");
	int N2=100;
	for(int i=0; i<N2;i++){
		double xnew2=(3.0/(N2-1))*i;
		step.WriteLine($"{xnew2}  {Af2.spline(xnew2)}  {Cf2.c_spline(xnew2)}");
		}//end for
	step.Close();

	


	return 0;}
}
