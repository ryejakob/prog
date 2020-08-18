using System;
using static System.Math;
using static System.Console;
using static vector;
using static qNewton;

public class main{
	static int Main() {
	
	//test function:
	Func<vector,double> f1= (x) => Pow(1-x[0],2)+100*Pow(x[1]-x[0]*x[0],2);
	vector xst1= new vector(2,3); //stating point
	int nr1 =0; //steps;
	double eps1=1e-5; //accuracy
	//using qnewton:
	vector min1=Downhill(f1,xst1,eps1, ref nr1);




	WriteLine($"Part C:");
	WriteLine($"{min1[0]}	{min1[1]}	{nr1}");


	return 0;}




}
