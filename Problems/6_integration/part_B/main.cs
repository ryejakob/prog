using System;
using static System.Math;
using static Integrator;
using static System.Console;
using static vector;
using static quad;

public class main{
	static int Main(){
	//test of cc-integrator
	//test functions:
	Func<double,double> f1 = (x) => 1/(Sqrt(x));
	Func<double,double> f2 = (x) => Log(x)/(Sqrt(x));
	
	// start and end points:
	double a=0; double b=1;
	
	//number of evaluations:
	int n1=0; int n1cc=0; int n2=0; int n2cc=0;

	double del=0.0001; double eps=0.0001;

	double R1=integrator(f1, a,b,del, eps, ref n1);
	double R1cc=CCin(f1, a,b,del, eps, ref n1cc);
	double R2=integrator(f2, a,b,del, eps, ref n2);
	double R2cc=CCin(f2, a,b,del, eps, ref n2cc);

	WriteLine($"Part B:");
	WriteLine($"i) Integration of 1/sqrt(x) from 0 to 1. (Note I used delta=1e-4 and epsilon=1e-4)");
	WriteLine($"The analytic result is 2."); 
	WriteLine($"The calculated result without transformation is {R1} with {n1} evaluations.");
	WriteLine($"The calculated result with CC-transformation is {R1cc} with {n1cc} evaluations");
	WriteLine($"");
	WriteLine($"ii) Integration of ln/sqrt(1-x*x) from 0 to 1. (Note I used delta=1e-4 and epsilon=1e-4)");
	WriteLine($"The analytic result is -4."); 
	WriteLine($"The calculated result without transformation is {R2} with {n2} evaluations.");
	WriteLine($"The calculated result with CC-transformation is {R2cc} with {n2cc} evaluations");
	
	WriteLine($"");
	WriteLine($"The CC-transformation seems to lower the number of needed evalutaions significant.");

	//the integral over 4*sqrt(1-x²) 

	//the function:
	Func<double, double> f3= (x) => 4*Sqrt(1-x*x);
	
	//number of eval
	int n3=0; int n3cc=0;

	//new del and eps
	double del3=1e-17; double eps3=0;
	
	//integration:
	double R3=integrator(f3,a,b,del3,eps3, ref n3);
	double R3cc=CCin(f3,a,b,del3,eps3,ref n3cc);
	
	WriteLine($""); 
	WriteLine($"iii) Integrate 4/(1-x²) from 0 to 1. Unless I set a limit on the number of elaluations of the integrator, both methods can find a pracition close to the machine epsilon. Calculated without CC: {R3}, with CC: {R3cc}, and analytic Pi: {PI}.");
	WriteLine($"");
	
	//accuracy and number of evaluations:

	//new output stream:
	var data=  new System.IO.StreamWriter("data.txt");
	for(int i=1; i<14; i++){
		double delnew=1/Pow(10,i);
		int n4=0;
		int n4cc=0;
		int n4o=0; 
		double R4=integrator(f3, a,b,delnew, eps3, ref n4);
		double R4cc=CCin(f3,a,b,delnew, eps3, ref n4cc);
		//to find the number of eval used in o8av you can use following trick:
		Func<double, double> f4 = (z) => {n4o++; return f3(z); };
		double R4o = o8av(f4, a,b,  delnew, eps3);
		data.WriteLine($"{delnew} {n4} {n4cc} {n4o}");  
		}//end for 
	data.Close();


	WriteLine("In plotB.svg the accuracy and number of evaluations is compared for my integrator the CC-model and o8av from matlib/integration"); 
	WriteLine("o8av is significant faster.");



	return 0;}
}
