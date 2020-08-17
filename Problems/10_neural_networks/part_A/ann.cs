using System;
using static System.Math;
using static vector;
using static qNewton;

//note to self: make the class so one can use train more times i a row for better resuts...

public class ann{ 

	//fields:
	public readonly int N; //number of hidden neurons
	//note (to self): readonly in this context means that N only can be assigned in class delaration (like here) or in the constructor...
	public Func<double,double> f; // the activation function, used in the hidden neurons
	public vector par; //vector containing the parameters (a, b , w) for the network...

	//constructor:
	public ann(int n1, Func<double,double> f1){
	N=n1;
	f=f1;
	// since each hiddden neurons has 3 associated parametes the size of the par vector is given as:
	par=new vector(3*n1); 
	}// ned constructor

	//feedforwad: gives the sum of the
	public double FF(double x1){
	double sum=0;
		for(int i=0; i<N; i++){
		//taking the input x, and transforming it by way of the hidden neurons
		double a=par[3*i];
		double b=par[3*i+1];
		double w=par[3*i+2]; //the parameters
		sum=sum+f((x1-a)/b)*w;
		}//end for 
	return sum; 
	}// end FF
	

	//method for traning of the ann...
	public void train(vector x, vector y){

	//defining the function for minimazation: 
	Func<vector, double> fmin = (v) => {
		par=v; //setting the network parameters to the indput
		double sum2=0; //the sum...
			for(int j=0; j<x.size; j++){ //loop over the elements in x and y
			sum2=sum2+Pow(FF(x[j])-y[j],2); 
			}//end for
		return sum2;
		};//end fmin 
	// now I just have to use my qnewton minimazation on fmin to find par... but I need at starting guess 
	//another student used the following:
	vector xst= new vector(3*N);
	double xmin = x[0];
	double xmax = x[x.size-1];
	double xstep = (xmax - xmin)/(N-1);
	for(int i = 0; i < N; i++) {
		xst[3*i+0] = xmin + i*xstep;
		xst[3*i+1] = xstep;
		xst[3*i+2] = 1;
		}// end for

	//using the minimazation:
	double eps=1e-6; //
	int nr=0; //number of steps

	vector pnew=qnewton(fmin, xst, eps, ref nr);

	par=pnew; //using the optimazation...
	}// end train




}//end class
