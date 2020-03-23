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
	vector dy=new vector(y.size);
	vector lny=new vector(y.size);
	vector dlny=new vector(y.size);
	for(int n=0; n<y.size; n++){
		dy[n]=y[n]/20;
		lny[n]=Log(y[n]);
		dlny[n]=dy[n]/y[n];
		}//end for
	Func<double,double>[] f= new Func<double, double>[]{(x) => 1, (x) => -x};
		
	olsf fit=new olsf(t,lny,dlny,f);

	//generate data...
	//for(int n1=0; n1<y.size; n1++){ 
	//WriteLine($"{t[n1]} {y[n1]} {dy[n1]}");
	//}//end for 

	vector a= fit.c;
	Func<double, double> F= (x) => Exp(a[0])*Exp(a[1]*x);
	matrix sigma=fit.Sigma;	

	//for(double n2=0; n2<20; n2+=0.05){
	//WriteLine($"{n2} {F(n2)}");
	//}
	WriteLine("The coveriance matrix takes the form:");
	WriteLine($"{sigma[0,0]} {sigma[0,1]}");
	WriteLine($"{sigma[1,0]} {sigma[1,1]}");
	Write("\n");
	
	vector dc=fit.dc;
	WriteLine($"The moderen value for the half life of 224Ra is 3.6319 days, the calculated value is given as {Log(2)/a[1]}");
	WriteLine($"The uncertenty of the calculated half life is {dc[1]/a[1]/a[1]}");


	return 0;	
}}
