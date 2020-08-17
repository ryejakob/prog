using static System.Math;
using static matrix;
using System;
using static vector;
using System.Collections.Generic;

public class rkODE{

public static vector[] rkstep12(Func<double,vector,vector> f, double t, vector yt, double h){
	vector k_0=f(t, yt);
	vector k_05=f(t+0.5*h,yt+0.5*h*k_0);
	//vector k=k_05;
	vector yh=yt+k_05*h;
	vector err=(k_05-k_0)*h/2;
	return new vector[] {yh, err};
	

}// end rkstep12

//A driver for rkstep12
public static int driver12(Func<double,vector,vector> f, double a, vector y, double b, double h, double acc, double eps, List<double> tl=null, List<vector> yl=null){  // Note that tl is a list of the steps taken and yl is a list of the function values to y(t).
	double t=a; // stating point
	double err1; //error norm
	vector yh=new vector(y.size); 
	int st=0; //step number
	int k=0; //number of acepted steps
	vector[] YaE;
	while(t<b-h){
		st++;
		YaE=rkstep12(f,t,y,h); // Taking the step by calling the stepper
		err1= Sqrt(YaE[1].dot(YaE[1])); //error from stepper
		double thau=(eps*Sqrt(YaE[0].dot(YaE[0]))+acc)*Sqrt(h/(b-a));//the local tolerance for the given step

		//test of the tolerance
		if(err1< thau){
		t=t+h; //updating the stating pioint
		tl.Add(t); //adding new t to the list
		yl.Add(YaE[0]); //adding new yh to the list
		y=YaE[0];
		} //end if 
		

		//new step size
		if(err1>0){
			h=h*Pow(thau/err1,0.25)*0.95;
			}//end if
		else{
			h=h*2;
			}//end else

		}// end while

	//one last step to get to the end point b. 
	st++; 
	h=b-t; //the last step size
	YaE=rkstep12(f,t,y,h); //the last step
	t=b; //updating the stating pioint
	tl.Add(t); //adding new t to the list
	yl.Add(YaE[0]); //adding new yh to the list	

	return st;
}// end driver12

}//end class
		
		
