using System;
using static System.Console;
using static System.Math;
//using static cmath;
using static epsi;

class main{
	static int Main(){

		WriteLine($"Part A:");
		WriteLine("i)");
		int i=1; while(i+1>i) {i++;}
		Write("my max int = {0}\n",i);
		Write($"int.MaxValue={int.MaxValue}\n"); 
		WriteLine("ii)");
		int k=1; while(k-1<k) {k--;}		
		Write("my min int = {0}\n",k);
		Write($"int.MinValue={int.MinValue}\n");
			
		WriteLine("Part B:");

		double x=1; while(1+x!=1){x/=2;} x*=2;
		Write("my double epsilon int = {0}\n",x);
		Write($"e={Pow(2,-52)}\n");
		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Write("my float epsilon int = {0}\n",y);
		Write($"e={Pow(2,-23)}\n");


		WriteLine("Part C");
		WriteLine("i)");

		int max=int.MaxValue/3;

		float float_sum_up=1F;
		for(int i1=2;i1<max;i1++)float_sum_up+=1F/i1;
		Write("float_sum_up={0}\n",float_sum_up);

		float float_sum_down=1F/max;
		for(int i1=max-1;i1>0;i1--)float_sum_down+=1F/i1;
		Write("float_sum_down={0}\n",float_sum_down); //
		WriteLine(" ii) the differace is due to round off errors... ");
		WriteLine(" iii) yes..");
		WriteLine("iv)");

	double double_sum_up=1F;
		for(int i1=2;i1<max;i1++)double_sum_up+=1F/i1;
		Write("double_sum_up={0}\n",double_sum_up);

		double double_sum_down=1F/max;
		for(int i1=max-1;i1>0;i1--)double_sum_down+=1F/i1;
		Write("double_sum_down={0}\n",double_sum_down);


WriteLine(" iv. the round off error is smaller...");
WriteLine("");

		WriteLine("Part D");	
		WriteLine($"Test of approx");
		var a = 1D;
		var b = a + 1e-11;
		Write($"a = {a} and b = {b} approx yields {approx(a, b)}\n");	
		b = a + 1e-8;
		Write($"a = {a} and b = {b} approx yields {approx(a, b)}\n");	



	return 0; } 
}
