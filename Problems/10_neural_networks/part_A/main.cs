using System;
using static System.Math;
using static System.Console;
using static vector;
using static ann;

public class main{
	static int Main(){
	// lets test using a Sin(x) function, and a gaussian as function
	//the gaussian
	Func<double, double> g = (x) => Exp(-x*x);
	 // the number of hidden neurons

	//generating the points 
	int n5=15;
	vector x5=new vector(n5);
	vector y5=new vector(n5);
	for(int i=0; i<n5; i++){
		x5[i]=2*i*(PI/n5);
		y5[i]=Sin(x5[i]);
		}//end for

	//using the class:
	ann AN1 = new ann(7, g);

	//train:
	AN1.train(x5,y5);
	//new output stream
	var data=  new System.IO.StreamWriter("out.data.txt");
	for(int i=0; i<100; i++){
		double xnew=2*i*(PI/100);
		data.WriteLine($"{xnew}  {Sin(xnew)}  {AN1.FF(xnew)}");
		}//end for
	data.Close();
	
	WriteLine($"Part A:");
	WriteLine($"Test of ann using a gaussian as function by interpolating Sin(x). In plotA.svg the interpolated function is plotted.");

	

	return 0;}
}
