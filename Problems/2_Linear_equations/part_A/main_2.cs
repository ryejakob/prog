using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;

public class main{
	static int Main() {
	
	matrix A = new matrix(3,3);
	
	A[0,0]= -0.503; A[0,1]=-0.779;A[0,2]=0.066;// A[0,3]=0.543;
	A[1,0]=0.315; A[1,1]=-0.134;A[1,2]=-0.292;// A[1,3]=0.888;
	A[2,0]=-0.797; A[2,1]=0.285;A[2,2]=-0.943;
	//A[3,0]=2; A[3,1]=3;A[3,2]=3;

	vector b= new vector(3);
	b[0]=-0.435; b[1]=0.231; b[2]=0.409;// b[3]=2;
	
	gram_s gr= new gram_s(A);
	matrix R=gr.R;
	matrix Q=gr.Q;
	
	vector x=gr.solve(b);
		
	vector ax=A*x;

	WriteLine("Test Ax=b"); 
	for(int n=0; n<b.size; n++){
	WriteLine($"Ax[{n}]={ax[n]} b[{n}]={b[n]}");
	}//end for
	



	return 0;
}}
