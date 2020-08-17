using System;
using static System.Math;
using static vector;
using static matrix;

public class qNewton{

	//A function to approximate the the gradient of f:
	public static vector gradient(Func<vector,double> f, vector x){
	double dx=1e-8;
	double fx=f(x);//saving f(x)
	vector nabla = new vector(x.size); //vector to the gradient
	for(int i=0; i<x.size; i++){
		x[i]=x[i]+dx;
		nabla[i]=(f(x)-fx)/dx;
		x[i]=x[i]-dx;
		}//end for
	return nabla; 
	}//end gradient
		

	public static vector qnewton(Func<vector,double> f, vector x, double eps, ref int nr){

	// as a start the B matrix is set to identety:
	matrix B = new matrix(x.size,x.size);
	B.set_identity();

	//define bool
	bool check1=true;
	
	while(check1){
	nr++; //update the nummber of steps... 
	//calculate the gradiant of f(x):
	vector nabla=gradient(f,x);
	//delta x can be calculated as:
	vector delx=(-1)*B*nabla;
	
	//back-tracking linesearch:
	double al=1e-4;
	double lam=1; 
	bool check2=true;
		while(check2){
			if(lam < 1.0/64){ //stopping while-loop if lam to small and reset B
			check2=false;
			B.set_identity();
			}//end if
			else if(f(x+lam*delx)< (f(x)+al*lam*(delx.dot(nabla))) ){ //accept if the step is good
			check2=false;
			}//end else if
			else{
			lam=lam/2; //
			}//end else
		}//end while

	//updata x: x=x+s
	x=x+lam*delx;
	//checking the error: 
	vector nabla2=gradient(f,x); //note if the while loop runs more then one thsi gradient is calculated 2 times, there might be a way around this...
	double err =nabla2.norm();
	
	if(nr>999){ //here 999 is the max number of steps the function is allowed
		check1=false;
		}//end if
	else if(err<eps) { // if the error is smaller then epsilon the result is accepted...
		check1=false;
		}//end else if
	else{
	//befor the the nest iteration the rank-1 opdata:
	vector y=nabla2-nabla;
	vector u=lam*delx-B*y;
	
	if(Abs(u.dot(y))>1e-6){ //the update
		matrix delB = new matrix(x.size,x.size);
		for(int i=0; i<x.size; i++){  //calculate delB
			for(int k=0; k<x.size; k++){
				delB[i][k]=u[i]*u[k]/(u.dot(y));
				}//end for
			}//end for
		B=B+delB;
		}// end if
	}//end else

	}//end while
	return x;
	}//end qnewton
	
	
			
	
	

	







}//end qNewton
