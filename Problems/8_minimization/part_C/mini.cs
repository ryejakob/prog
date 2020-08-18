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
	
	
	public static vector Downhill(Func<vector,double> f, vector x, double eps, ref int nr, double stepsize=1/5, int maxnr=999){
	
	// defining p (saved as vector list) and phi (vector) 
	vector[] p=new vector[x.size+1];
	double[] phi=new double[x.size+1];
	//generating starting p... using given step size...
	p[x.size]=x.copy();
	phi[x.size]=f(p[x.size]);
	for(int k=0; k< (x.size); k++){
		p[k]=x.copy();
		p[k][k]=p[k][k]+stepsize;
		phi[k]=f(p[k]);
		}//end for
	int il=0; int ih=0;
	double sum=2*eps;

	while(sum>eps && nr<maxnr){
	//new step:
	nr++; sum=0;
	
	ih=0; 
	il=0; //idex of highest point and lowest point; 
	//finding the points:
	ih=0;il=0;
	double pH=phi[ih],pL=phi[ih]; //values at the highest and lowst points
	for(int k=1;k<p.Length;k++){
		double p1=phi[k];
		if(p1>pH){pH=p1;ih=k;}
		if(p1<pL){pL=p1;il=k;}
		}

/*
	for(int i=0; i< (x.size+1); i++){
		double p1= phi[i];
		if(p1>pH){
			pH=p1;
			il=i;
			System.Console.Error.WriteLine($"{pH}");
			}//end if
		if(p1<pL){
			pL=p1;
			il=i;
			}//end if
		}//end for
 */
	//making pce:
	vector pce= new vector(x.size);
	for(int k=0; k<p[0].size; k++){
		if(k!=ih){
			pce+=p[k];
			}//end if
		}//end for
	pce=pce/x.size;
	//making refection:
	vector pre=pce+(pce-p[ih]);
	if(f(pre)<pL){
		//try expansion:
		vector pex=pce+2*(pce-p[ih]);
		if(f(pex)<f(pre)){
			//accept expansion:
			p[ih]=pex;
			phi[ih]=f(pex);
	System.Console.Error.WriteLine($"ex1 {nr}");
			}//end if
		else{
			//accept refection
			p[ih]=pre;
			phi[ih]=f(pre);
	System.Console.Error.WriteLine($"re1 {nr}");
			}//end else
		}//end if
	else if(f(pre)<pH){
		//appept refection
		p[ih]=pre;
		phi[ih]=f(pre);
	System.Console.Error.WriteLine($"re2 {nr}");
		}//end else
	else{
	//try contraction 
		vector pco= new vector(x.size);
		pco=pce+(p[ih]-pce)/2;
		if(f(pco)<pH){
			//accept contraction
			p[ih]=pco;
			phi[ih]=f(pco);
				System.Console.Error.WriteLine($"con {nr} {p[ih][0]}");
			}//end if
		else{
			//reduction
			for(int i=0; i<p[0].size; i++){
				if(i !=il){
					p[i]=(p[i]-p[il])/2;
					phi[i]=f(p[i]);
					}//end if
				}//end for
				System.Console.Error.WriteLine($"red {nr} {p[ih][0]}");
			}//end else
		}//end else
	for(int i=1;i<p.Length;i++){
		sum=Max(sum,(p[0]-p[i]).norm());
		}//end for

	}//end while 
	vector vec=p[il];
	return vec;
	}//end Downhill
		


}//end qNewton
