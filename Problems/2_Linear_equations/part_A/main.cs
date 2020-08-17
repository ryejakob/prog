using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;
using static RandMatrix;

public class main{
	static int Main() {
	
	//generating a random matrix 
	matrix A = randmatrix(4,3);


	
	gram_s a1 = new gram_s(A);

	matrix Q=a1.Q;
	matrix R=a1.R;
	
	WriteLine("Part A");
	WriteLine($"i) in-place modified Gram-Schmidt");
	WriteLine($"Random generated matrix A:");
	for(int i=0; i<A.size1; i++){
		Write("\n");	
		for(int j=0; j<A.size2; j++){
		Write($"{A[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("R-matrix takes the form:");
	for(int i=0; i<R.size1; i++){
		Write("\n");
		for(int n1=0; n1<R.size2; n1++){
		Write($"{R[i,n1]}	");
		}
	} Write("\n \n");

	WriteLine($"Test that Q^T*Q =1 :"); matrix qt=Q.T;
	matrix Q1=qt*Q;
	for(int i=0; i<Q1.size1; i++){
		Write("\n");
		for(int n1=0; n1<Q1.size2; n1++){
		Write($"{Q1[i,n1]}	");
		}
	} Write("\n \n");
	

	WriteLine("Test that QR=A");
	matrix Q2=Q*R;
	for(int i=0; i<Q2.size1; i++){
		Write("\n");
		for(int n1=0; n1<Q2.size2; n1++){
		Write($"{Q2[i,n1]}	");
		}
	} Write("\n \n");


	//end part i)
	

	//new random matrix:
	matrix A1=randmatrix(4,4);
	//new random vector:
	vector b=randvector(4);
	
	//factorize A into QR:
	gram_s a2 = new gram_s(A1);

	matrix Qn=a2.Q;
	matrix Rn=a2.R;
	
	//solve QRx=b
	vector x=a2.solve(b);
	//test ax=b
	vector ax=A1*x;

	WriteLine($"ii) Solve linear equation:");
	WriteLine($"New random matrix A:");
	WriteLine("Part A");
	for(int i=0; i<A1.size1; i++){
		Write("\n");	
		for(int j=0; j<A1.size2; j++){
		Write($"{A1[i,j]}	");
		}
	} Write("\n \n");
	WriteLine($"random vector b:");
	for(int i=0; i<b.size; i++){
		WriteLine($"{b[i]}");		
	} Write("\n");
	WriteLine($"A factorize into QR gives Q:");
	for(int i=0; i<Qn.size1; i++){
		Write("\n");	
		for(int j=0; j<Qn.size2; j++){
		Write($"{Qn[i,j]}	");
		}
	} Write("\n \n");
	WriteLine($"and R:");
	for(int i=0; i<Rn.size1; i++){
		Write("\n");	
		for(int j=0; j<Rn.size2; j++){
		Write($"{Rn[i,j]}	");
		}
	} Write("\n \n");
	WriteLine($"the system QRx=b was solved yeilding x:");
	for(int i=0; i<x.size; i++){
		WriteLine($"{x[i]}");		
	} Write("\n");
	WriteLine($"Ax becomes:");
	for(int i=0; i<ax.size; i++){
		WriteLine($"{ax[i]}");		
	} Write("\n");
	
	
	
	
	return 0;
}}
