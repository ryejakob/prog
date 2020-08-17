using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;
using static olsf;
using System;

public class main{
	static int Main() {
	//the data:
	//time
	vector t =new vector(9);
	t[0]=1;t[1]=2;t[2]=3;t[3]=4;t[4]=6;t[5]=9;t[6]=10;t[7]=13;t[8]=15;
	//activity
	vector y = new vector(9);
	y[0]=117;y[1]=100;y[2]=88;y[3]=72;y[4]=53;y[5]=29.5;y[6]=25.2;y[7]=15.2;y[8]=11.1; 
	//vectors:
	vector dy=new vector(y.size);
	vector lny=new vector(y.size);
	vector dlny=new vector(y.size);
	var data=new System.IO.StreamWriter("data.txt");
	for(int n=0; n<y.size; n++){
		dy[n]=y[n]/20; //error on y
		lny[n]=Log(y[n]);
		dlny[n]=dy[n]/y[n]; //error Ln(y)
		data.WriteLine($"{t[n]}  {y[n]} {dy[n]}");
		}//end for
	data.Close();

	//The function:
	Func<double,double>[] f= new Func<double, double>[]{(x) => 1, (x) => -x};
	
	//making the fit:
	olsf fit=new olsf(t,lny,dlny,f);
	//the calculated parameters:
	vector a= fit.c;
	//making a new function using the parameters:
	Func<double, double> F= (x) => Exp(a[0])*Exp(-a[1]*x);
	
	//generating points to fit:
	var fi=new System.IO.StreamWriter("fit.txt");
	for(double n2=0; n2<20; n2+=0.05){
		fi.WriteLine($"{n2} {F(n2)}");
		}//end for
	fi.Close();
	
	double hl=Log(2)/a[1]; //calculated half life
	double hlt=3.6319;
	double devi=Abs(hlt/hl-1)*100;
	WriteLine("Part A:");
	WriteLine("In plotA.svg is a plot of the experimental data and my best calculated fit.");
	WriteLine($"The moderen value for the half life of 224Ra is 3.6319 days, the value calulated from the fit is given as {Log(2)/a[1]} days. This is a deviation of {devi} %.");


	return 0;	
}}
