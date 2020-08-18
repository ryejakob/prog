using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using static System.Math;
using static ode;
using static vector;

class main{
	static void Main(){

	Func<double, vector, vector> f1 = (x,y) => new vector (y[0]*(1 - y[0]));

	double a=0;
	double b=3;
	vector ya= new vector(0.5);

	List<double> x1 = new List<double>();
	List<vector> y1 = new List<vector>();	

	ode.rk23(f1, a, ya, b,x1,y1);
	
	for (int n = 0; n < x1.Count; n++){
		WriteLine($"{x1[n]} {y1[n][0]}");
	}





}
}
