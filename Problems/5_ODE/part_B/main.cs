using System;
using static System.Math;
using static rkODE;
using static System.Console;
using System.Collections.Generic;
using static vector;

public class main{
	static int Main() {
	double Tc=4;
	double Tc2=1;
	double Tc3=2; 
	double Tc4=8; 
	//The population of Denmark is rougly 5.8 mil. 
	double N= 5.8e6;
	//The recovery time is under two week (note that some take up to six)
	double Tr=12;//unit days...

	//Lets say that DK has 1000 infected, at a given point in time.
	double I0=1000;

	// Let look at the first 100 days:
	double te=100;

	//start vector:
	vector ys=new vector(3);
	ys[0]=N-I0; ys[1]=I0; ys[2]=0;

	//step:
	double h=0.01;

	//acc and eps..
	double acc=0.0001;
	double eps=0.0001;
	
	//Lists:
	List<double> tl1 = new List<double>();
	List<vector> yl1 = new List<vector>(); 
	List<double> tl2 = new List<double>();
	List<vector> yl2 = new List<vector>();
	List<double> tl3 = new List<double>();
	List<vector> yl3 = new List<vector>();
	List<double> tl4 = new List<double>();
	List<vector> yl4 = new List<vector>();

	//the functions:
	Func<double, vector, vector> f1 = (t,y) => new vector(-(y[1]*y[0])*1/(N*Tc), (y[1]*y[0])*1/(N*Tc)-y[1]/Tr,y[1]/Tr);
	Func<double, vector, vector> f2 = (t,y) => new vector(-(y[1]*y[0])*1/(N*Tc2), (y[1]*y[0])*1/(N*Tc2)-y[1]/Tr,y[1]/Tr);
	Func<double, vector, vector> f3 = (t,y) => new vector(-(y[1]*y[0])*1/(N*Tc3), (y[1]*y[0])*1/(N*Tc3)-y[1]/Tr,y[1]/Tr);
	Func<double, vector, vector> f4 = (t,y) => new vector(-(y[1]*y[0])*1/(N*Tc4), (y[1]*y[0])*1/(N*Tc4)-y[1]/Tr,y[1]/Tr);


	//using the rutine 
	int st= driver12(f1, 0, ys, te, h,  acc,  eps, tl1, yl1);	
	st= driver12(f2, 0, ys, te, h,  acc,  eps, tl2, yl2);
	 st= driver12(f3, 0, ys, te, h,  acc,  eps, tl3, yl3);
	 st= driver12(f4, 0, ys, te, h,  acc,  eps, tl4, yl4);	

	//output to plot 1:
	var data1=new  System.IO.StreamWriter("data1.txt");
	for(int i=0; i< tl1.Count; i++){
		data1.WriteLine($"{tl1[i]} {yl1[i][0]} {yl1[i][1]} {yl1[i][2]}");
		}; //end for
	data1.Close();
	//more output:
	var data2=new  System.IO.StreamWriter("data2.txt");
	for(int i=0; i< tl2.Count; i++){
		data2.WriteLine($"{tl2[i]} {yl2[i][0]} {yl2[i][1]} {yl2[i][2]}");
		}; //end for
	data2.Close();

	var data3=new  System.IO.StreamWriter("data3.txt");
	for(int i=0; i< tl3.Count; i++){
		data3.WriteLine($"{tl3[i]} {yl3[i][0]} {yl3[i][1]} {yl3[i][2]}");
		}; //end for
	data3.Close();
	
	var data4=new  System.IO.StreamWriter("data4.txt");
	for(int i=0; i< tl4.Count; i++){
		data4.WriteLine($"{tl4[i]} {yl4[i][0]} {yl4[i][1]} {yl4[i][2]}");
		}; //end for
	data4.Close();

	WriteLine("Part B:");
	WriteLine("SIR-model");
	WriteLine($"For my model i set the total population of Denmark to {N}, the recovery time to {Tr}, the number of infected at time=0 is set to {I0} and the model run over 100 days.");
	WriteLine($"In plotT4.svg the SIR-model is seen for Tc={Tc} (in this model most of population end op having recovert from the infection)");
	WriteLine($"In plotS.svg, plotI.svg and plotR, the behavior of  the S, I and R parameters is compared for differnt Tc");

	return 0;}
}
