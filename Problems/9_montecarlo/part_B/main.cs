using System;
using static System.Math;
using static System.Console;
using static vector;
using static montecarlo;

public class main{
	static int Main(){
	//testing in 1-D: Sin²(x) from 0 to 2*pi
	//the function: 
	Func<vector,double> f= (x) => Sin(x[0])*Sin(x[0]);
	
	//start and end points:
	vector a=new vector(0.0);
	vector b=new vector(2*PI);
	int Ns=1000;
	var data=  new System.IO.StreamWriter("out.data.txt");
	for(int N=Ns; N<50000; N=N+100){ // number of sampling points
	//calling plainmc
	double K;
	vector F=plainmc(f, a, b, N);
	if(N==Ns){K=F[1];};

	data.WriteLine($"{N} {F[1]}  {Abs(F[0]-PI)}  {1/Sqrt(N)}");
	}//end for
	data.Close();

	WriteLine($"Part B:");
	WriteLine($"In plotB.svg, the error of the plain Monte-Carlo method is seen with a O(1/sqrt(N))");	WriteLine($"");
		

	return 0;}
}
