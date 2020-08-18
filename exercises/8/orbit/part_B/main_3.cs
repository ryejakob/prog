using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using static System.Math;
using static ode;
using static vector;

class main{
	static void Main(){
	
	Func<double, vector, vector> f1 = (x,y) => new vector (y[1], 1-y[0]+0.01*y[0]*y[0]);
	double a1=0;
	double b1=50;
	vector ya1= new vector(1,-0.5);
	List<double> list_x1 = new List<double>();
	List<vector> list_y1 = new List<vector>();	

	ode.rk23(f1, a1, ya1, b1, list_x1, list_y1);
	
	for (int n = 0; n < list_x1.Count; n++){
		WriteLine($"{list_x1[n]} {list_y1[n][0]}");
	}

}
}
