using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;
using static olsf;
using System;

public class main{
	static int Main() {
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
		dy[n]=y[n]/20;
		lny[n]=Log(y[n]);
		dlny[n]=dy[n]/y[n];
		data.WriteLine($"{t[n]} {y[n]} {dy[n]}");
		}//end for
	data.Close();
	Func<double,double>[] f= new Func<double, double>[]{(x) => 1, (x) => -x};
		
	olsf fit=new olsf(t,lny,dlny,f);

	vector a= fit.c;
	Func<double, double> F= (x) => Exp(a[0])*Exp(-a[1]*x);
	vector dc= fit.dc;
	Func<double, double> dFp= (x) => Exp(a[0]+dc[0])*Exp(-(a[1]+dc[1])*x);
	Func<double, double> dFm= (x) => Exp(a[0]-dc[0])*Exp(-(a[1]-dc[1])*x);

	var fi=new System.IO.StreamWriter("fit.txt");
	for(double n2=0; n2<20; n2+=0.05){
		fi.WriteLine($"{n2} {F(n2)} {dFp(n2)} {dFm(n2)}");
		}//end for
	fi.Close();
	
	WriteLine("Part C:");
	WriteLine("The relevant figure is plotC.svg");
	
	

	return 0;	
}}
