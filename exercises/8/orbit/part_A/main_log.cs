using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){

	for(double n=1; n<=10; n++){
		double x=n*3/10;
		WriteLine($" {x} {1/(1+Exp(-x))}");
		}
}}
