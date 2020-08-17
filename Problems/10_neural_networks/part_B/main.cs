using System;
using static System.Math;
using static System.Console;
using static vector;
using static ann;

public class main{
	static int Main(){
	// lets test using a Sin(x) function, and a gaussian wevelet as function
	//the gaussian wevelet
	Func<double, double> g = (x) => x*Exp(-x*x);
	
	Func<double,double> difg= (x) => (1-2*x*x)*Exp(-x*x); //derivative of g
	Func<double,double> Intg= (x) => -Exp(-x*x)/2; //anti-derivativ of g
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
	ann AN1 = new ann(7, g, difg, Intg);

	//train:
	AN1.train(x5,y5);
	//offset of int:
	double os=-Cos(PI)-AN1.FFint(PI);

	//new output stream
	var data=  new System.IO.StreamWriter("out.data.txt");
	for(int i=0; i<100; i++){
		double xnew=2*i*(PI/100);
		data.WriteLine($"{xnew}  {Cos(xnew)} {-Cos(xnew)} {AN1.FFdif(xnew)}  {AN1.FFint(xnew)+os}");
		}//end for
	data.Close();
	
	WriteLine($"Part B:");
		WriteLine($"In this part a gaussian wavelet is used. ANN is once again tested by intpolate Sin(x).");
		WriteLine($"In plotdif.svg the approximated derivative is plotted with the table value, and in plotint.svg the anti-derivative is plotted with the table value.");

	return 0;}
}
