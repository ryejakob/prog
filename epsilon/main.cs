using System;
using static System.Console;
using static System.Math;
//using static cmath;
using static epsi;

class main{
	static int Main(){
//		int i=1; while(i+1>i) {i++;}
//		Write("my max int = {0}\n",i);
//		Write($"int.MaxValue={int.MaxValue}\n"); 
//		int k=1; while(k-1<k) {k--;}		
//		Write("my min int = {0}\n",k);
//		Write($"int.MinValue={int.MinValue}\n");

//		double x=1; while(1+x!=1){x/=2;} x*=2;
//		Write("my double epsilon int = {0}\n",x);
//		Write($"e={Pow(2,-52)}\n");
//		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
//		Write("my float epsilon int = {0}\n",y);
//		Write($"e={Pow(2,-23)}\n");

//		int max=int.MaxValue/3;

//		float float_sum_up=1F;
//		for(int i=2;i<max;i++)float_sum_up+=1F/i;
//		Write("float_sum_up={0}\n",float_sum_up);

//		float float_sum_down=1F/max;
//		for(int i=max-1;i>0;i--)float_sum_down+=1F/i;
//		Write("float_sum_down={0}\n",float_sum_down); // ii) the differace is due to round off errors... 
// iii. yes..

///	double double_sum_up=1F;
//		for(int i=2;i<max;i++)double_sum_up+=1F/i;
//		Write("double_sum_up={0}\n",double_sum_up);

//		double double_sum_down=1F/max;
//		for(int i=max-1;i>0;i--)double_sum_down+=1F/i;
//		Write("double_sum_down={0}\n",double_sum_down);


// iv. the round off error is smaller...	
		//double  approx(double x) {return Math.Exp(x);}
		//double g1=1e-10; double g2=2e-10;
		//WriteLine($"bool={approx(g1)}");
// test of epsilon function		
		double a=8; double b=16;
		
		WriteLine($"{approx(a,b)} {approx(a,a)}");



	return 0; } 
}
